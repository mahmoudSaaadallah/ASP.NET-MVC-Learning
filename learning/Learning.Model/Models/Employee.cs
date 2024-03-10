using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Learning.Model
{
    public class Employee
    {
        // We used here the data annotation Key to refer to the Id is the primary key.
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string Name { get; set; }
        [Required]
        [Range(2500, 100000)]
        public double Salary { get; set; }
        [Required]
        [RegularExpression("^\\d+\\s+((\\w+\\.?\\s*)+)(\\b\\w*\\b\\s*)+,\\s*(\\w+\\.?\\s*)+,?\\s*\\w{2,3}\\s*\\d{5}(?:-\\d{4})?$\r\n")]
        public string Address { get; set; }

        // we made the Image property here nullable as we don't want to make the Image property required.
        [AllowNull]
        [RegularExpression("\\.(jpg|png)$\r\n")]
        public string? Image { get; set; }


        // Now we have a relationship between the Employee and Department Model.
        // The type of this relationship is one to many.
        // The Department contains many employees and each Employee belongs to one department.
        // To apply this relationship we have to Navigation property.



        // Here we have the relational column which is the foreign key from the Department table.
        // We have to use the Data annotation of foreign key to make it clear for Entity framework.
        // The foreign key accept the name of the Navigation property.
        [ForeignKey("Department")]
        public int Dep_Id { get; set; }

        // This is the navigation property 
        // We made the Navigation prop Virtual because we don't want it to make a new object
        //   each time i want to get employee's department I want the entity framework
        //   provides lazy loading behavior.
        // This mean when we want to get employee's department it will change the data of the
        //   existing Department to suited the employee.

        public virtual Department? Department { get; set; }

        // After we make the relation between the Department and the Employee table we need
        //   now to go to the Department model and make a list of employees there to make the
        //   relation be one to many .



        // We will add the IsDeleted property here as a bool and give it default value as
        //   false to apply the soft delete as we don't want to delete the employee when we
        //   delete it we want to hide it by making this property equal to true and when we
        //   work with data from the employee table we will work with only the undeleted
        //   records. This way used to save the old operation and data as arch.

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }



        // Now when we add a migration to database we will find that there is a prop that 
        //  onDelete: ReferentialAction.Cascade
        // This prop means if the department is deleted then all the employees in this
        // department will be deleted also, but this doesn't make any sense, so we have to change it to be
        //  onDelete: ReferentialAction.NoAction
        // This means don't delete the employees when we delete there department, and let the developer responsible for handling them.

        // Or we could change it to be:
        //  onDelete: ReferentialAction.SetNull
        // This means if the department is deleted then all the employees in this department
        //   will being set to null in the departmentId column.
    }
}
