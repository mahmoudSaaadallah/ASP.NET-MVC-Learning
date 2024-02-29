using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace learning.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [RegularExpression("[a-zA-Z]")]
        public string Name { get; set; }
        [AllowNull]
        [RegularExpression("\\.(jpg|png)$\r\n")]
        public string? ImageUrl { get; set; }
        [Required]
        [Range(2500, 100000)]
        public double Salary { get; set; }
        [Required]
        [RegularExpression("^\\d+\\s+((\\w+\\.?\\s*)+)(\\b\\w*\\b\\s*)+,\\s*(\\w+\\.?\\s*)+,?\\s*\\w{2,3}\\s*\\d{5}(?:-\\d{4})?$\r\n")]
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
