using Learning.DataAccess;
using Learning.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning.Controllers
{
    public class CourseResultController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            List<CourseResult> result = _context.CoursesResults
                .Include(i => i.Course)
                .Include(i => i.Trainee)
                .Where(i => i.IsDeleted == false).ToList();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            CourseResult result = _context.CoursesResults
              .Include(i => i.Course)
              .Include(i => i.Trainee)
              .Where(i => i.IsDeleted == false).FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                return View("NotFoundEx");
            }
            return View(result);
        }
    }
}
