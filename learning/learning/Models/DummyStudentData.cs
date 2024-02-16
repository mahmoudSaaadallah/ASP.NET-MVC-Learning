namespace learning.Models
{
    public class DummyStudentData
    {
        public List<Student> students;
        public DummyStudentData() { 
            students = new List<Student>();
            students.Add( new Student()
            {
                Id = 1,
                Name = "Omar",
                Address = "123 Main Street",
                Image = "gg.png"
            });
                students.Add(new Student()
            {
                Id = 2,
                Name = "Ahmed",
                Address = "all the way street",
                Image = "img.jpg"
            });
                students.Add(new Student()
            {
                Id = 3,
                Name = "Osman",
                Address = "ling",
                Image = "IMG_٢٠١٩١١٢١_٠٠٥٣٠١.jpg"
            });
        }
        public List<Student> GetAll()
        {
            return students;
        }
        public Student GitById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
    
}
