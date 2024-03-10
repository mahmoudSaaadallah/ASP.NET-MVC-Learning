using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace Learning.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage =("this filed is Required"))]
        [MinLength(3)]
        [MaxLength(25)]
        [RegularExpression(@"^[A-Za-z]+(?:[ -][A-Za-z]+)*$")]
        [Remote(action: "chStudentNameExist", controller:"Student", ErrorMessage ="This name already used.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d+\s+[\w\s]+,\s*\w+,\s*\w+\s+\d{5}$")]
        public string Address { get; set; }
        [AllowNull]
        [RegularExpression("\\.(jpg|png)$\r\n")]
        public string? Image { get; set; }
    }
}
