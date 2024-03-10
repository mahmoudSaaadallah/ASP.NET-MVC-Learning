using System.Security.Policy;

namespace Learning.Model
{
    public class StudentViewModel
    {
        public string Message { get; set; }
        public List<string> Nationality { get; set; }
        public int StudentId { get; set; }  
        public string StudentName { get; set; }
        public string Address { get; set; } 
        public string ImageUrl { get; set; }
    }
}
