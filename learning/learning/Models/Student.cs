using System.ComponentModel.DataAnnotations;

namespace learning.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
