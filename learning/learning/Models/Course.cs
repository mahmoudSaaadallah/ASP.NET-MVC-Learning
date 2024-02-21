using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learning.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public int Degree { get; set; }

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
