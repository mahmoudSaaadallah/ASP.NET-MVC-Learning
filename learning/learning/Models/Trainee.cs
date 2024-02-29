using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace learning.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string Name { get; set; }
        [AllowNull]
        [RegularExpression("\\.(jpg|png)$\r\n")]
        public string? ImageUrl { get; set; }
        [Required]
        [RegularExpression("^\\d+\\s+((\\w+\\.?\\s*)+)(\\b\\w*\\b\\s*)+,\\s*(\\w+\\.?\\s*)+,?\\s*\\w{2,3}\\s*\\d{5}(?:-\\d{4})?$\r\n")]
        public string Address { get; set; }
        [Required]
        [Range(0, 500)]
        [RegularExpression("[0-9]")]
        public int Grade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId {  get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<CourseResult>? CoursesResults { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
