using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learning.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 500)]
        [RegularExpression("[0-9]")]
        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public virtual Trainee? Trainee { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
