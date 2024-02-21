using learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning.Controllers
{
    public class InstructorController : Controller
    {

        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            List<Instructor> result = _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .Where(i => i.IsDeleted == false).ToList();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            Instructor result = _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .Where(i => i.IsDeleted == false).FirstOrDefault(i => i.Id == id);
            if(result == null)
            {
                return View("NotFoundEx");
            }
            return View(result);
        }
    }
}
