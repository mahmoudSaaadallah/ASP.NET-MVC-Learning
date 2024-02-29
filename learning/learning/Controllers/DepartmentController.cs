using learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext _Context = new ApplicationDbContext();
        public IActionResult Index()
        {
            // We have to know that the dot net framework doesn't support laze loading as if 
            //    if have a Navigation prop in one of table refer to another table this
            //    Navigation will not added when we select data and it will be null by
            //    default.
            // If you want to make a lazy loading then you have to use Include to include the navigation property
            List<Department> departments = _Context.Department.Where(d => d.IsDated == false).ToList();

            // Applying Laze loading
            List<Department> departments2 = _Context.Department.Include(d => d.Employees).Where(d => d.IsDated == false).ToList();

            return View(departments2);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                _Context.Department.Add(department);
                _Context.SaveChanges();
                return RedirectToAction("Index", "Department");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
    }
}
