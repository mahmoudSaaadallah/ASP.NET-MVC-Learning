using Learning.DataAccess;
using Learning.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning.Controllers
{
    public class CourseController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            List<Course> result = _context.Courses
                .Include(i => i.Department)
                .Include(i => i.Instructors)
                .Include(i => i.CoursesResults)
                .Where(i => i.IsDeleted == false).ToList();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            Course result = _context.Courses
                 .Include(i => i.Department)
                 .Include(i => i.Instructors)
                 .Include(i => i.CoursesResults)
                 .Where(i => i.IsDeleted == false).FirstOrDefault(i => i.Id == id);
            if (result == null)
            {
                return View("NotFoundEx");
            }
            return View(result);
        }
    }
}
