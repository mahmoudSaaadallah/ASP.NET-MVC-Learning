using Learning.Model;
using Learning.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Student student)
        {
            Student studentDB = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if(studentDB != null)
            {
                studentDB.Name = student.Name;
                studentDB.Address = student.Address;
                if(studentDB.Image != null )
                {
                    studentDB.Image = student.Image;
                }
            }
        }
    }
}
