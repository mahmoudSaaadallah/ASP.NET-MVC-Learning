using learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext _dbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            // We have to know that the dot net framework doesn't support laze loading as if 
            //    if have a Navigation prop in one of table refer to another table this
            //    Navigation will not added when we select data and it will be null by
            //    default.
            // If you want to make a lazy loading then you have to use Include to include the navigation property
            List<Department> departments = _dbContext.Department.Where(d => d.IsDated == false).ToList();

            // Applying Laze loading
            List<Department> departments2 = _dbContext.Department.Include(d => d.Employees).Where(d => d.IsDated == false).ToList();

            return View(departments2);
        }
    }
}
