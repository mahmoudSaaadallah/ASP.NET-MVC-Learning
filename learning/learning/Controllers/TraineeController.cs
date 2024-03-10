using Learning.DataAccess;
using Learning.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning.Controllers
{
    public class TraineeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            List<Trainee> result = _context.Trainers
                .Include(i => i.Department)
                .Include(i => i.CoursesResults)
                .Where(i => i.IsDeleted == false).ToList();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            Trainee result = _context.Trainers
                .Include(i => i.Department)
                .Include(i => i.CoursesResults)
                .Where(i => i.IsDeleted == false).FirstOrDefault(i => i.Id == id);
            List<Course>d =_context.Courses.Where(i => i.IsDeleted == false).
                Where(c => c.DepartmentId == result.DepartmentId).ToList();
            if (result == null)
            {
                return View("NotFoundEx");
            }
            var g = d.Select(i => i.MinimumDegree).ToList();
            var g1 = result.CoursesResults.Select(r => r.Degree).ToList();
            TraineeDetailsViewModel traineeDetailsViewModel = new TraineeDetailsViewModel();
            traineeDetailsViewModel.Id = id;
            traineeDetailsViewModel.Name = result.Name;
            traineeDetailsViewModel.Cresults = result.CoursesResults;
            traineeDetailsViewModel.Courses = d;
            for(int i = 0; i < g.Count(); i++)
            {
                if (g1[i] >= g[i])
                {
                    traineeDetailsViewModel.color = "green";
                }
                else
                {
                    traineeDetailsViewModel.color = "red";
                }
            }
            return View(traineeDetailsViewModel);
        }
    }
}
