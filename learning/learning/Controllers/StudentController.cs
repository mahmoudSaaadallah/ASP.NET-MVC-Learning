using learning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace learning.Controllers
{

    // All the controllers classes must end with "Controller" in their name.
    public class StudentController : Controller
    {
        #region Intro_For_Controllers


        // All the public methods in Controller classes are called Action methods.
        // These Action Methods need some rules to work:
        // 1. It must be public to be used so it can't be Private.
        // 2. It must be non static as the static methods shared for all the objects in the
        //     class so they can't be static methods.
        // 3. Can't be overloaded, There are some cases where we can overload these methods,
        //     but it can't be overloaded in the normal situation.


        // We have to know that all the action methods will be routed to be used in the
        //   browser and the way of routing is:
        // localHost/controllerName/actionName
        // localHost/controller/ActionMethod.


        // Type of return for ActionMethods.
        // 1. Simple string which called "Content"   ===> ContentResult.
        // 2. View which is HtmlPages.               ===> ViewResult.
        // 3. JavaScript.                            ===> JavaScriptResult
        // 4. Json.                                  ===>JsonResult.                    
        // 5. NotFound.                              ===> NotFoundResult
        // 6. File.                                  ===> FileResult
        // 7. RedirectResut. 
        // 8. RedirectToRouteResult.

        // MVC Make a class for each return type that the Action methods could return.


        // To route the following method it will be .
        //  Student/ShowMes
        public ContentResult ShowMes()  
        {
            // Declare the ContentResult
            ContentResult result = new ContentResult();
            // Set data.
            result.Content = "This is a content result Action method";
            // return result.
            return result;
        }

        // Routing
        //   Student/ShowView
        public ViewResult ShowView()
        {
            // We have to know that when we use the ViewResult the return result file must
            //   be exist in the Views folder in the a sub folder with the same name of
            //   controller or  in the shared view sub folder.
            // So we will create a view file with the name of TestViw in sub folder called
            //   Student in Views folder.
            // The name of sub folder inside the views folder must be the same as the name
            //   of controller.
            ViewResult result = new ViewResult();
            result.ViewName = "TestView";
            return result;
        }
        // Routing 
        //   Student/ShowJson
        public JsonResult ShowJson()
        {
            JsonResult result = new JsonResult(new { Id = 1, name = "Test" });
            return result;
        }


        // In some cases may be you need to make an action method return different type of
        //   results for example you need to return ContentResult if something happen else
        //   you want to return ViewResult.
        // In this case you can't use the normal return method, but you could use the
        //   IActionResult type as this type could return any result that implements
        //   IActionResult interface, as all the results implement IActionResult interface
        //   then it will be better to use it with all the return type.

        // Routing 
        //   Student/ShowMix?IntNumber
        //   Student/ShowMix/IntNumber
        //   Student/ShowMix?id=IntNumber
        public IActionResult ShowMix(int id)
        {
            if(id % 2 == 0)
            {
                ContentResult result = new ContentResult();
                result.Content = "divided by 2";
                return result;
            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "TestView";
                return result;
            }
        }


        // After we try all the above we will find that there is something shared between all
        //   the action methods which is all of them need a declaration for return type and
        //   set data then return result, so Microsoft make some functions that could be used
        //   in return directly instead of declaration for result, and all of these functions
        //   automatically declare the return type.
        // Like View(), which accept the name of view that must be returned.
        // Json() that accept the Json that must be returned.
        // Content() that accept the content must be returned.
        public IActionResult ShowStudent(int id)
        {
            return Content("Student");
        }
        public IActionResult ShowStudentView()
        {
            // We have to know that View method has four overloads 
            // one of them doesn't accept any parameter so it will return view withe same
            //   name of method.
            // The second overload accepts one parameter which is the name of view file.
            // The Third one accepts Two parameters one for nameof view and the other for the
            //   name of model that will be used in this view.
            return View("TestView");
        }

        #endregion

        public IActionResult Details(int id)
        {
            DummyStudentData dummyStudentData = new DummyStudentData();
            Student student = dummyStudentData.GitById(id);
            if (student == null)
            {
                return View("NotFoundEx");
            }
            return View("Details",student);
        }
        public IActionResult Index()
        {
            DummyStudentData dummyStudentData = new DummyStudentData();
            List<Student> students = dummyStudentData.GetAll();
            return View(students);
        }
    }
   
}
