using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string Name { get; set; }
        [Required]
        [Range(0, 500)]
        [RegularExpression("[0-9]")]
        public int Degree { get; set; }
        [Required]
        [Range(0, 500)]
        [RegularExpression("[0-9]")]
        public int MinimumDegree { get; set; }  

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<CourseResult>? CoursesResults { get; set;}


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
