using learning.Models;

namespace learning.ViewModels
{
    public class TraineeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public List<Course> Courses { get; set; }
        public List<CourseResult> Cresults { get; set; }
        public string color { get; set; }


    }
}
