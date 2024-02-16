using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace learning.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        // Here we will make a prop of type list<Employee> which will refer to the relation between Department and Employee.
        // We will make it also virtual to provide lazy loading behavior.
        
        public virtual List<Employee>? Employees { get; set; }


        // We will add the IsDeleted property here as a bool and give it default value as
        //   false to apply the soft delete as we don't want to delete the department when we
        //   delete it we want to hide it by making this property equal to true and when we
        //   work with data from the department table we will work with only the undeleted
        //   records. This way used to save the old operation and data as arch.
        [DefaultValue(false)]
        public bool IsDated { get; set; }
    }
}
