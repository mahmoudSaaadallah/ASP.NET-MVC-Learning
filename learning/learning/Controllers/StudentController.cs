using Azure.Core;
using Learning.DataAccess;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Buffers.Text;
using System;
using System.Diagnostics.CodeAnalysis;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using Humanizer;
using Microsoft.VisualBasic;
using Mono.TextTemplating;
using NuGet.ContentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Numerics;
using Learning.DataAccess;
using System.Security.AccessControl;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Microsoft.EntityFrameworkCore.Metadata;
using NuGet.Common;
using System.Net;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Routing;
using static System.Net.WebRequestMethods;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Http.HttpResults;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.Packaging.Signing;
using System.Runtime.InteropServices;
using Azure;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;
using System.Drawing;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using NuGet.Protocol.Core.Types;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis;
using System.Collections;
using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp;
using Learning.Model;
using Microsoft.Build.Evaluation;
using System.Runtime.ConstrainedExecution;
using Learning.DataAccess.Repository;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using static learning.Controllers.StudentController;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Hosting;
using Learning.Model.IRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;
using BindAttribute = System.Web.Mvc.BindAttribute;

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


        private ApplicationDbContext _context = new ApplicationDbContext();
        UnitOfWork _unitOfWork;
        public StudentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
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
        #region Sending data from Action To View
        // We have four different ways to send data from Action to the view.
        // 1. Using Normal Model.
        // 2. Using ViewData.
        // 3. Using ViewBag.
        // 4. Using ViewModel.
        public IActionResult TestViewData()
        {
            DummyStudentData dummyStudentData = new DummyStudentData();
            List<Student> students = dummyStudentData.GetAll();

            // As we know when we use Action method that returns View then we could return also
            //   a model to the view, but we could return only one model, but in some cases we
            //   need to return more than one model to the view which is not supported.
            // To solve this problem microsoft provide a class of Type ViewData which is a class
            //   that implements IDictionary<string, object?> interface.

            // The ViewData class is a dictionary type which has a key as a string and value as
            //   an object.
            // The ViewData automatically passed to the View(razor) page so when we use ViewData
            //   and assign any data to it we could use this data in View.


            #region ViewData in Details:
            // Here's a detailed overview of ViewData:

            // Purpose: ViewData is used to pass data from a controller to a corresponding view.
            // It allows you to transfer information or state between the controller and the view,
            //   enabling dynamic content rendering in the view based on the data provided by the controller.


            // Type: ViewData is of type ViewDataDictionary, which is essentially a dictionary
            //   collection that stores key - value pairs.
            // It inherits from IDictionary<string, object>, meaning it behaves like a dictionary
            //   where keys are strings and values are objects.


            // Lifetime: Unlike ViewBag, which is dynamic, ViewData is not dynamic.
            // This means you need to cast its values explicitly when accessing them in the view.
            // The data stored in ViewData persists only for the current request and is available
            //   to the view being rendered during that request.


            // Usage: You can set values in ViewData in a controller action method and then access
            //   those values in the corresponding view.
            // Values can be of any type, but you need to handle null checks and casting properly in
            //   the view to avoid runtime errors.
            ViewData["Message"] = "Hello from ViewData!";
            /*
            < !--Accessing data from ViewData in a view -->
            < h1 > @ViewData["Message"] </ h1 >
            */


            // Casting: Since ViewData is not dynamic, you need to cast its values appropriately
            //   when accessing them in the view.
            // This helps ensure type safety and avoid runtime errors.
            /*
             <!-- Casting and accessing data from ViewData -->
            <h1>@((string)ViewData["Message"])</h1>
            */

            // Alternatives: While ViewData can be useful for passing data between a controller
            //   and a view, it's generally recommended to use strongly-typed models
            //   (using @model directive) instead of ViewData when possible.
            // Strongly-typed models provide better type safety, IntelliSense support, and
            //   cleaner code organization.
            #endregion

            ViewData["Message"] = "Hello";
            ViewData["Nationality"] = new List<string> { "Egyption", "American", "Indian" };

            return View(students);
        }
        public IActionResult TestViewBag()
        {
            DummyStudentData dummyStudentData = new DummyStudentData();
            List<Student> students = dummyStudentData.GetAll();

            // As we said before we can't sen more than one model to view and we discussed the
            //   the ViewData to solve this problem, but we said the ViewData has some
            //   disadvantages like naming of key and casting.
            // Microsoft solve the disadvantages of ViewData and created a ViewBag.
            // The best thing in ViewBag is it Dynamic type which means it doesn't need casting
            // And also it works as prop.

            #region ViewBag In Details:
            // ViewBag is a dynamic property provided by ASP.NET MVC that allows you to pass
            //   data from a controller to a view.
            // It serves as a wrapper around ViewData, which is a dictionary-like object used
            //   for the same purpose.
            // We have to know that when we access or set data in ViewBag, We but it in a
            //   ViewData, but we access it as a property not as a Dictionary.
            // Here's a detailed overview of ViewBag:

            // Purpose: ViewBag is used to transfer data or state from a controller to its
            //   corresponding view in ASP.NET MVC applications.
            // It enables passing dynamic information from the controller to the view for
            //   rendering dynamic content.


            // Dynamic Nature: Unlike ViewData, which requires explicit casting, ViewBag is
            //   dynamic.
            // This means you can set and access its properties directly without needing to cast them.
            // It provides a more convenient syntax for accessing data in views.


            // Lifetime: The data stored in ViewBag is available for the duration of the current
            //   request only.
            // It's typically used to pass data from the controller to the view being rendered
            //   during that request.
            // After the request completes, the ViewBag properties are no longer accessible.


            // Usage: You can set values in ViewBag within a controller action method and then
            //   access those values directly in the corresponding view.
            // Values can be of any type, and you can access them using property syntax without casting.
            ViewBag.Message = "Hello from ViewBag!";
            /*
             <!-- Accessing data from ViewBag in a view -->
             <h1>@ViewBag.Message</h1>
             */


            // Dynamic Access: Since ViewBag is dynamic, you don't need to cast its values when
            //   accessing them in the view.
            // This simplifies the syntax and makes the code more concise and readable.


            // Cautions: While ViewBag provides a convenient way to pass data between
            //   controllers and views, its dynamic nature can lead to runtime errors if not
            //   used carefully.
            // You need to ensure that the properties you access actually exist in the ViewBag
            //   to avoid exceptions.


            // Alternatives: Although ViewBag can be useful for passing simple data, it's
            //   generally recommended to use strongly-typed models (using @model directive)
            //   instead of ViewBag for passing complex data structures.
            // Strongly-typed models offer better type safety, IntelliSense support, and
            //   cleaner code organization.
            #endregion


            ViewBag.Message = "Hello";
            ViewBag.Nationality = new List<string> { "Egyption", "American", "Indian" };
            return View(students);
        }
        public IActionResult TestViewModel(int id)
        {
            DummyStudentData dummyStudentData = new DummyStudentData();
            List<Student> students = dummyStudentData.GetAll();

        // Now after discussing the ViewData, and ViewBag which have a disadvantages some of
        //   developers found another solution that solve the problems that apeare with 
        //   ViewData and ViewBag.
        // The solution is to use the ViewModel Pattern.

        #region ViewModel In Details:
        // A ViewModel in ASP.NET MVC is a pattern used to represent the data that a view
        //   needs to display, often aggregating data from multiple models or containing
        //   additional properties not present in the domain models.
        // ViewModels are designed to encapsulate the specific data and behavior needed by
        //   a particular view, thereby improving separation of concerns and flexibility in
        //   the application architecture.

        // Here's a detailed overview of ViewModels:

        // Purpose: ViewModels are used to tailor data for presentation in views.They help in
        //   decoupling the views from the underlying domain models, ensuring that views only
        //   receive the necessary data for rendering and are not directly tied to the internal
        //   structure of the models.


        // Data Aggregation: ViewModels often aggregate data from multiple domain models.
        // For example, if a view needs to display information about a user and their associated
        //   roles, a ViewModel can aggregate data from both the User and Role domain models.


        // Additional Properties: ViewModels may contain additional properties not present in
        //   the domain models but required for presentation logic in the view.
        // These properties can include calculated fields, display formatting information, or
        //   any other data relevant to the view but not part of the domain model.


        // Flexibility: ViewModels provide flexibility in shaping the data presented to views.
        // They allow developers to customize the structure of the data specifically for each
        //  view's requirements, facilitating better separation of concerns and maintainability.


        // Type Safety: ViewModels are typically strongly typed, meaning they are classes with
        //   well-defined properties.
        // This provides type safety and IntelliSense support, helping to catch errors at
        //   compile-time rather than runtime.


        // ViewModel Naming Convention: While there's no strict naming convention for
        //   ViewModels, it's common practice to suffix ViewModel class names with "ViewModel"
        //   to distinguish them from domain models.For example, UserViewModel,
        //   ProductDetailsViewModel, etc.


        // ViewModel Binding: In ASP.NET MVC, ViewModel objects are typically passed from the
        //   controller to the view via the @model directive at the top of the view file.
        // This directive specifies the type of the ViewModel expected by the view, enabling
        //   strong typing and IntelliSense support in the view.
        #endregion


        // It's better to make ViewModel in another project and import it here, but as we need
        //   just to test it we will make a folder to test it.
        ViewBag.Nationality = new List<string> { "Egyption", "American", "Indian" };
        StudentViewModel stm = new StudentViewModel();
            stm.Address = students.FirstOrDefault(s => s.Id == id).Address;
            stm.StudentId = id;
            stm.StudentName = students.FirstOrDefault(s => s.Id == id).Name;
            stm.ImageUrl = students.FirstOrDefault(s => s.Id == id).Image;
            stm.Message = "hello";
            stm.Nationality = ViewBag.Nationality;
            return View(stm);
        }

        #region Session and TempData in The State Management:

        // We have to know that when we search about URL in browser the server open a session
        //   for you this session contains response for your request What we mean by open a
        //   session is the server make an object of the controller that you asked for and give
        //   it an id then send this id to the client, but when the response is received to the
        //   client the server automatically deletes the object that used for this request and
        //   all the data associated with this controller will be deleted, but the web page
        //   doesn't close as the data that returned with response transferred to HTML contents
        //   which is static so it can't be deleted. 
        // Sometimes we need to store some data to use it in another request in the same session
        //   but we can't as the object will be deleted when the response is received.

        // HTTP is a stateless protocol. By default, HTTP requests are independent messages
        //   that don't retain user values. 
        // We have to know that we work with HTTP protocol which can't save state of data after
        //   the response.

        // Session state is an ASP.NET Core scenario for storage of user data while the user
        //   browses a web app.
        // Session state uses a store maintained by the app to persist data across requests
        //   from a client.
        // The session data is backed by a cache and considered ephemeral data.
        // The site should continue to function without the session data.
        // Critical application data should be stored in the user database and cached in
        //   session only as a performance optimization.

        // As we said when we use  HTTP protocol and we want to store user data to use it in
        //   another Controller or in another request we can't do it as the Http protocol
        //   deletes all the controller data after the response is received by the client
        //   some times we need to use some data in another request to do it we have several
        //   ways to store data per session per browser not per request.


        // The first way is to store the session data in cookies using TempData:
        // This way is very useful as we could store the session data in a cookies and use it in
        //   another request as the session is still open.

        // TempData:
        // TempData in ASP.NET MVC is a dictionary-like structure used to pass data between
        //   controller actions and views.
        // It's specifically designed to persist data for the duration of the current HTTP
        //   request and the subsequent HTTP request, making it useful for scenarios such
        //   as passing messages or data between action methods that redirect to one another.
        // This mean the TempData is passed to the views like ViewData ViewBag which are
        //   Dictionaries like TempData.

        //   Here's a detailed overview of TempData:

        // Purpose: TempData allows you to store data temporarily across requests in the same Session.
        // It's often used for scenarios where you need to pass data from one action method to
        //   another when using a redirect, such as displaying confirmation messages or passing
        //   form data after a redirection.

        // Lifetime: Data stored in TempData persists for the current request and the subsequent
        //   request only.
        // After that, the data is automatically cleared.
        // This makes TempData suitable for scenarios where you need to pass data between
        //   actions during a redirect but don't need it to persist beyond that.
        // We have to know that when we normally read the Temp data in another action method or
        //   in the same action method it automatically deleted from cookies so it used to read for once.
        // Also When the time of the session expires the cookies of tempData will be deleted.

        // Usage: You can set and retrieve data in TempData similar to how you work with a
        //   dictionary.
        // It provides methods like Add, Remove, and indexer access to set and retrieve data.
        //  TempData["Message"] = "Data to pass";
        // Here we set data in TempData dictionary. 
        //  string message = TempData["Message"] as string;
        // Here we retrieve data from TempData dictionary and it will deleted automatically.

        // Type Safety: Like ViewBag, TempData is a dictionary of objects, so you need to cast
        //   data when retrieving it.
        // It's essential to handle null values and proper type casting to avoid runtime errors.

        // Usage with Redirects: TempData is commonly used in scenarios involving redirects,
        //   where data needs to be preserved across actions that result in a redirect.
        // After the redirect, you can retrieve the data from TempData and use it in the
        //   redirected action.

        // Flash Messages: One common use case of TempData is for displaying flash messages,
        //   such as success or error messages, to users after a form submission or an action
        //   completion.
        // You set the message in TempData in one action, redirect to another action, and then
        //   display the message in the view.
        // This like notification that appears when you post something in facebook or add
        //   something or delete something. 

        // Performance Considerations: While TempData can be convenient for passing data across
        //   redirects, it's essential to use it judiciously, as storing large amounts of data
        //   in TempData can impact performance.
        // Only store necessary data that needs to persist across the redirect.

        public IActionResult TestTempData()
        {
            string message = "Hello";
            // As we see here we used the tempData prop to store a string and this temp data
            //   will be used in another action method.
            TempData["msg"] = "Temp1";
            return Content(message);
        }
        public IActionResult get1()
        {
            // As we see here we used the tempData that already stored in the previous action
            //   method, but we have to know that here when we try to retrieve the temp data
            //   this mean it will deleted as we used the normal way to read data from the temp
            //   data.
            // So if used this action method before using the get2 Action method this means the
            //   get2 action method will not be able to access the temp data again as the temp
            //   data will be deleted after being retrieved.

            string message = TempData["msg"].ToString();
            return Content("Get1" + message);
        }
        public IActionResult get2()
        {
            // Here if we try to access temp data after the get1 accessed it then this method
            //   will return null reference exception as the temp data will be deleted after the
            //   first read operation.
            string message = TempData["msg"].ToString();
            return Content("Get2" + message);
        }
        // There are two ways to access the temp data without deleting it after reading
        //   operation.
        // First way is to use the Keep() method.
        // TempData.Keep("msg");
        // This line of code must be used we access the temp data to keep it from being deleted 
        //   after the read operation.

        // Also there is another way to access the temp data without deleting it
        // Second way is to use Peek() method
        // TempData.Peek("msg");
        // This line of code will access the temp data and retrieve its value without deleting
        //   it.

        public IActionResult get11()
        {
            // Here we will use the Peek() method to access the temp data and retrieve its value
            //   without deleting it.

            string message = TempData.Peek("msg").ToString();
            return Content("Get11" + message);
        }
        public IActionResult get22()
        {
            // Here we will use the keep() method after reading the temp data to store it again
            //   and don't loss its value.

            string message = TempData["msg"].ToString();
            TempData.Keep("msg");
            return Content("Get22" + message);
        }





        // We already now know how to use the tempData which stored in cookies, but we said that
        //   the tempData will be deleted after the first normal read operation.
        // What about if i want to store someData without losing it after reading operations?
        // To do that we need to store this data in the server side not in the client side like tempData.
        // So we have to Session to store data:
        // As we know that the session has more life time and has lot of action methods, then
        //   It's better to store data in the Session If we want this data to be used multiple times.


        // Session:
        // Session in ASP.NET is a server-side state management mechanism that allows you to
        //   store user-specific information across multiple requests and pages during a
        //   user's session.
        // It provides a way to maintain user state and data throughout their interaction with
        //   a web application.


        // Here's a detailed overview of Session:


        // Purpose: The primary purpose of Session is to store user-specific information that
        //   needs to be maintained across multiple requests and pages during a user's session.
        // It enables the web application to recognize and remember individual users and their
        //   interactions.


        // Lifetime: Session data persists for the duration of a user's session with the web
        //   application.
        // A session starts when a user accesses the application for the first time and ends
        //   when the user closes the browser, their session times out due to inactivity, or
        //   explicitly ends through code.
        // The session also could be ended when the user stop react with the browser for a
        //   specific period of time it's 20 minutes by default and we could change it.


        // Storage Mechanism: By default, Session data is stored on the server-side, typically
        //   in memory or in a separate out-of-process state server.
        // However, you can configure it to use other storage mechanisms such as SQL Server,
        //   Redis, or custom providers.


        // Usage: You can store and retrieve data in Session using a key-value pair approach,
        //   similar to a dictionary.
        // You can store objects of any serializable type.
        // It's important to note that storing large objects in session can impact server
        //   memory and performance, so it's generally recommended to store only essential data.
        // To use session to store data we have to use HttpContext
        // HttpContext.Session.SetString("key", "value");
        // As we see here in this line of code we use the HttpContext class which contains the
        //   Session prop which has a SetString() method that accepts key and value pairs like dictionary.
        // Also the Session Contains another method SetInt32() Which also accepts key and value
        //   pairs like dictionary but the value must be integer.
        // HttpContext.Session.SetInt32("age", 12);

        public IActionResult TestSession()
        {
            HttpContext.Session.SetString("Name", "Omar");
            HttpContext.Session.SetInt32("Age", 15);
            return Content("The data added to the session.");
        }
        public IActionResult GetSession1()
        {

            // Here we use the GetString and GetInt32 methods to retrieve data from the session.
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content("The name is: " + name + "The Age is: " + age);
        }

        // If we tried now to run the application it will return an error message:
        // InvalidOperationException: Session has not been configured for this application or request.
        // This error message mean that we can't use the session to store the data without adding its pipeline.
        // So we have to back again to the program.cs to add the pipeline for session.




        // Session Management: ASP.NET provides several ways to manage sessions, including
        //   cookie-based session management and session state management using a session
        //   identifier (SessionID). You can configure session settings in the web.config file
        //   or through code.


        // Security Considerations: Since Session data is stored on the server-side, it's
        //   generally considered more secure than client-side storage mechanisms like cookies.
        // However, you should still be cautious about storing sensitive information in Session,
        //   as it can potentially be accessed by other users if session security is compromised.


        // Scalability: When using in-process session state (i.e., storing session data in
        //   memory), scalability can be a concern, especially in web farm scenarios.
        // In such cases, consider using out-of-process or distributed session state mechanisms
        //   to ensure scalability and reliability.


        // To read Session in any View we use:
        // @Context.Session.GetString("KeyName");

        #endregion


        #region Cookies

        // As we sow before when we dealing with TempData we stored the information on the 
        //   client side, but the life time of the TempData end when the Session end or when
        //   someone read it by the normal reading.
        // Also we sow that when we dealing with Session we stored data in the server side,
        //   which is more secure and has much life time as the session data not deleted when
        //   someone read it just end when the session end.

        // Some time I want to store data in the client side for long period of time like days,
        //   weeks or even more, and this situation is not available in TempData and Session, so
        //   they introduce the Cookies which has long lifetime and used to store data in the 
        //   client side.

        // Cookies:

        // Cookies are small pieces of data that are sent by a web server to a user's web
        //   browser during their visit to a website.
        // These cookies are stored on the user's device and are sent back to the server with
        //   subsequent requests.
        // Cookies are widely used in web development for various purposes, such as session
        //   management, personalization, tracking, and authentication.

        // Here's a detailed overview of cookies:

        // 1. Purpose: Cookies serve multiple purposes in web development. Some common use cases include:
        //  Session Management: Cookies can be used to maintain session state, allowing the
        //    server to recognize a user across multiple requests during a single session.
        //  Personalization: Cookies can store user preferences or settings, enabling a
        //    personalized browsing experience.
        //  Tracking: Cookies can track user behavior and interactions on a website, such as
        //    page views, clicks, or navigation paths.
        //  Authentication: Cookies can be used to authenticate users, storing authentication
        //    tokens or session identifiers to validate user sessions.
        //  Advertising: Cookies can be used for targeted advertising by tracking user interests
        //    and behavior across websites.


        // Lifetime: Cookies can have different lifetimes, depending on how they are configured:
        //   Session Cookies: These cookies are temporary and are stored only for the duration
        //     of a user's session.
        //   They are typically deleted when the user closes their browser.
        //   Persistent Cookies: These cookies have an expiration date set by the server and
        //     can persist on the user's device for a specified period, even after the browser
        //     is closed.


        // Storage: Cookies are stored locally on the user's device, typically in a text file
        //   or database managed by the browser.
        // Each cookie contains a name-value pair and additional attributes such as expiration
        //   date, domain, and path.


        // Security: While cookies are widely used for various purposes, they also pose security
        //   and privacy concerns. Some common security considerations include:
        //   Cookie Tampering: Cookies can be intercepted or modified by attackers, leading to
        //     security vulnerabilities such as session hijacking or data tampering.
        //   Cross-Site Scripting(XSS): Malicious scripts injected into web pages can access
        //     and manipulate cookies, potentially exposing sensitive information.
        //   Privacy: Cookies can track user behavior and preferences, raising privacy concerns
        //     about user data collection and tracking practices.


        // HTTP Cookies: HTTP cookies are the most common type of cookies used in web development.
        // They are sent as HTTP headers in the request and response messages exchanged between
        //   the client and server.
        // The Set-Cookie header is used to set cookies on the client, while the Cookie header
        //   is used to send cookies back to the server.


        // Client-Side Access: Cookies are accessible on the client-side via JavaScript,
        //   allowing developers to read, write, or delete cookies using the document.cookie API.
        // However, access to cookies is subject to browser security restrictions, such as the
        //   same-origin policy.


        // Regulations: Due to privacy concerns, there are regulations governing the use of
        //   cookies, such as the General Data Protection Regulation (GDPR) in the European
        //   Union and the California Consumer Privacy Act (CCPA) in the United States.
        // These regulations require websites to obtain user consent for non-essential cookies
        //   and provide mechanisms for users to control cookie settings.


        
        // The best example on cookies is when you sing in as a new user in any website and you
        //   choose remember me to make the website remember you when you try to login again in
        //   this case your Authentication data will be stored in cookies.

        public IActionResult TestCookies()
        {
            // we have to know that the cookies are like the dictionary which mean it accept key
            //   and value pairs.
            // Also the cookies accept only string Values.

            // To set data inside cookies we use the Response Which is an object of class
            //   HttpResponse class which contains The Cookies prop which is type of
            //   IResponseCookies that contains the Append() method Which is responsible for 
            //   Adding a new cookie and value.

            // The Append() method has three overloads:
            // 1. That accept the key and the Value that will be stored in cookies.

            // 2. That accept the key, the value that will be stored in cookies and the CookieOptions.
            // The CookieOptions is a class that contains some properties like Domain, Path,
            //   Expires, MaxAge, and even more properties that define how to deal with the cookies.


            Response.Cookies.Append("Name", "Mahmoud");
            // We have to know that the default life time for the cookies is the session
            //   lifetime, but we could we change it using the Cookie options in the second
            //   overload method to Append().
            Response.Cookies.Append("Age", "22");

            // We have two type of cookies
            // 1. The session cookies which end with the end of the session lifetime.
            // 2. The persistent cookies which end with lifetime that you choose.
            Response.Cookies.Append("love", "Shrouk", new CookieOptions {Expires = DateTimeOffset.Now.AddDays(1) }) ;
            // Here we make a cookie with lifetime one day as the CookieOptions.Expires now has
            //   been set to one day.
            return Content("The cookies already stored.");
        }
        public IActionResult GetCookies()
        {
            // To read the data from Cookies we use the Request which is an object of type
            //   HttpRequest class that contains a Cookies prop that is type of
            //   IRequestCookieCollection then we could pass the key of data that you want to
            //   read.

            string name = Request.Cookies["Name"];
            // Here we make casting to integer as the cookies store only strings.
            int age = int.Parse(Request.Cookies["Age"]);
            return Content($"Data from Cookies {name} {age}");
        }


        #endregion

        #endregion


        #region Accepting Data From View To Model.

        // We have a different ways to send data from View to Model
        // 1. Using Form.
        // 2. Using anchor. 
        // 3. Using JQuery.

        // Form:
        // We have two ways to send data using Form one of them by using Query string, and
        //   the other by using FormData.

        // Query String means: When add a form in the view and the method of this form is Get
        //   then all the data in this form will be sent to the Url as a Query string.
        // FormData means: When add a form in the view and the method of this form is Post then all the data in this form will be sent to the body as hidden.


        // We know that the Url in MVC consist of
        //  ControllerName/MehodName/DataThatThisMethodAccept
        // As this is the shape of Url then We could use the form with method get to send
        //   data in the Url as a Query string.


        // But now the point is How the Asp.NET MVC will get this data from view to Action?
        // This happens by ModelBinding.

        #region ModelBinding:

        // Model binding is a process in ASP.NET MVC that maps data from an HTTP request to
        //   action method parameters or model properties.
        // It automatically converts incoming request data (such as form values, query string
        //   parameters, or route values) into .NET objects, simplifying the process of
        //   handling user input in controller actions.

        //   Here's a detailed overview of model binding:

        // Purpose: Model binding simplifies the process of extracting data from incoming
        //   HTTP requests and populating .NET objects with that data.
        // It abstracts away the complexities of parsing and converting raw request data,
        //   allowing developers to work with strongly-typed objects in their controller actions.


        // Types of Model Binding:
        // Parameter Binding: In parameter binding, data from the request is bound to action
        //   method parameters.For example, when a form is submitted, form field values are
        //   bound to method parameters.
        // Model Binding: In model binding, data is bound to properties of a model object.
        //  This is useful for binding complex objects with multiple properties, such as view
        //  models or domain models.

        // Let's try using Parameter Binding:
        // By considering that we have view that contains a form inside it and this form
        //   contain two input one has name of Name and the other named Age.
        // This form uses the method get, so the data will be send inside the Url as a query string
        // So if we enter the Name = "Ahmed" and Age = 22 then the Url will be:
        // Student/TestParameterBinding?Name=Ahmed&Age=22
        public IActionResult TestParameterBinding(string Name, int Age)
        {
            // Now As we see the result will be the data the already collected from view.
            // What happen here is the when you call an action that accepts data the Binding will
            //   automatically be search about this data in formData first If he find it he will stop
            //   and back again else he will search again in Route data which is Anchor if else will
            //   search again in QueryString.
            // The question know how the binding mechanism know each variable and its data?
            //   this happen if we use the same name of Variable in input inside form in html.
            // So to make binding work correct, The parameter Name must be the same as input from client.
            // 
             
            return Content($"Name: {Name} , Age: {Age}");
        }


        // Also we could accept a Collection like list, array, or dictionary.
        // Lets consider that we have an action that accepts a Dictionary with key string and value int,
        //   and also accepts string Name.
        // When we send data to this action as a query string the Url will be:
        // Student/TestCollectionBinding?Name=Ahmed&data[ahmed]=22&data[omar]=141
        // As we can see in the Url the data has been sent twice, As we use a collection then we could
        //   save more than one value so we could rapeat the data in url and each time it will be sent
        //   to Dictionary as a record.
        public IActionResult TestCollectionBinding(Dictionary<string, int> data, string Name)
        {
            // As we could see the two records will be sent if we used the previous Url to data dictionary.
            return Content($"name = {Name} ");

        }


        // Model Binding:
        // The model binding start if the action accepts a class.
        // The model binding mechanism will work depend on the prop in this Model(class).
        // In the following Action method it accepts a student model and this model contains properties
        //   like Id, Name, Address so let's try this Url
        // Student/TestModelBinding?Id=2&Name=Ahmed&Address=aga
        public IActionResult TestModelBinding(Student st)
        {
            // As the Url contains Variables name as the Properties inside Student model then this
            //   values we will send to this model.
            return Content($"id:{st.Id}, Name:{st.Name}");
        }

        // I could also customize model binding to accept specific properties for model using data annotations.
        // As we see in the following Action method we accept Student with custom bind
        // If we use the same Url that we used before:
        // Student/TestModelBinding?Id=2&Name=Ahmed&Address=aga
        // As we see here we send the Id, Name, and Address in Url, but we custom bind to accept only 
        //   Id and Name, so the bind will ignore Address, and accept only Id and Name.
        public IActionResult TestCustomModelBinding([Bind(Include ="Id, Name")]Student st)
        {
            // As the Url contains Variables name as the Properties inside Student model then this
            //   values we will send to this model.
            return Content($"id:{st.Id}, Name:{st.Name}");
        }



        // Default Binders: ASP.NET MVC provides default model binders for binding common data types,
        //   including primitives, strings, enums, and complex objects.
        // These default binders are capable of handling most scenarios out-of-the-box.


        // Custom Binders: Developers can create custom model binders to handle specialized scenarios
        //   or custom data types.
        // Custom model binders implement the IModelBinder interface, which defines a BindModel method
        //   responsible for performing the binding logic.


        // Binding Sources: Model binding can extract data from various sources within an HTTP request, including:
        // Form values: Data submitted via HTML form fields.
        // Query string parameters: Data appended to the URL as key-value pairs.
        // Route values: Data extracted from route parameters defined in the URL route template.
        // Header values: Data included in HTTP headers.
        // JSON or XML body: Data sent in the request body in JSON or XML format.


        // Parameter Names: Model binding matches incoming request data to action method parameters
        //   or model properties based on parameter names.
        // By convention, parameter names should match the names of form fields, query string
        //   parameters, or route values.


        // Model State: After model binding, ASP.NET MVC validates the bound model and adds validation
        //   errors to the model state.
        // Developers can check the model state in their controller actions to handle validation errors
        //   and provide appropriate feedback to users.


        // Usage: Model binding is typically used in controller actions to extract data from HTTP
        //   requests and pass it to other parts of the application, such as service layers or data
        //   access layers.
        // It simplifies data handling and promotes separation of concerns by keeping controller
        //   actions focused on request processing.

        #endregion


        #endregion




        #region Create new record
        // When we want to create a new Object of this class, we need two Action methods one to open a
        //   view which contains form that will accept data and one to submit it to the database.
        // let's consider that we want to make a View that is responsible for making a new student then 
        //   we need an action method to open this View, and when we submit it to the database we will
        //   need another action method that accepts data from View and sends it to the database.

        public IActionResult Create()
        {
            return View();
        }
        // Now after we create an action method that will be responsible for Opening The View that
        //   contain form for creating a new student.
        // We made the View Create with form of method Post to make sure that the data will not be sent
        //   to query string in Url 
        // Now we have to make another action method that accepts data and sends it to the database.

        // In this action method we have to know that how the data will be pass from JS Validations 
        // As if some one try to send data that is not valid and this data has been sent to query
        //   string in Url then this data will not pass from Validation and it will be sent directly to
        //   data base, So To make sure that the data must pass from Validation JS then we have to make 
        //   sure that the user will press the Submit button and will not has the ability to submit data
        //   to Url, So the Action method that accepts data will have a specific data Annotation 
        [HttpPost]
        // The HttpPost mean that the following method will not be called until the user press the
        //   submit button, Which means the data will pass through JS Validations.

        // Now what about security sometimes hacker take the same view of your login page and make
        //   another one with the same design and send the link of this page for the people to sign in
        //   in your website as the users know your design of your website they will think that they
        //   are using your website and they will enter their data and the hacker in this case will
        //   make a valuable to accept the data that the users enter and he will make the action of
        //   his form  refer to your website so your website will be open after the user enter his
        //   data and the user will think that he used the right website but he will never know that
        //   his data has been stalled
        // To prevent this thing we could use an attribute set responsible for not accepting any
        //   tokens from foreign website or from foreign pages he will accept talking the only from
        //   the local website which means your domain.
        [ValidateAntiForgeryToken]
        // so the validate anti-forin token is a variable that used to not accept or to make sure that
        //   the data has been sent from the domain of the website not from a foreign to domain
        public IActionResult Create(Student st)
        {
            // here we could  put a backend Validation like Validates if the st is not Null and another things like validate each prop in st and so on...
            _context.Students.Add(st);
            _context.SaveChanges();
            // The Way of back again to the index View is kind of complicated as We can't use 
            // return View("Index");
            // As the Index View needs a specific model, So we can't go to it directly without an action
            //   method that will send this model to it.
            // So The best way is to call the Action method that is responsible for Index View, but this
            //   also can't be happen with Action method, but Microsoft provides another way to call
            //   Action method using RedirectToAction().

            // RedirectToAction() is a method that is responsible for calling a specific Action method.
            // It has Seven overloads methods
            // 1. that Accept nothing, So this will back again to the same Action method that call it.
            // 2. that Accept the name of Action method as a string.
            // 3. that Accept the name of Action method as a string, and Route Value if the calling
            //      Action Accept data
            // 4. that the name of Action method as a string and the name of Controller as a string this
            //      used if you want to go to Action in another controller.
            // 5. that the name of Action method as a string, the name of Controller as a string, and
            //      the route Value.
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        #endregion



        #region Edit a record
        
        // Now after we talked about creating new record and add it to data base 
        //   we have to know how to update an existing record.
        // The update process is same as the create process as we need with update 
        //   two Action method one to open form that will contain the old data of
        //   the record and one for submitting data and send it to data base after
        //   modifying it.

        public IActionResult Edit(int Id)
        {
            Student student = _context.Students.FirstOrDefault(s => s.Id == Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (student != null)
            {
                
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                return RedirectToAction("Edit", student.Id);
            }
        }

        #endregion



        // If we go to edit view we will find that we made a form to that contains some inputs which
        //   accept data from client side and sent it to server side.
        // But if look to one of these input tags we will find it look like this:
        // <input type="text" id="propName" Name="propName" Value=@model.propName/>
        // As we see here we but the Name of input as the name of prop that will accept this data 
        //   or it will not work, as if we miss spill the prop name in input tag it will not work 
        //   also this way doesn't has an auto complete so it will be difficult to deal with way.
        // Micro soft provide another two features that will solve this problem
        // The first way is to use Html Helper.
        // As we know the View inherit ViewBag, ViewData, and TempData it also inherit Html helper.

        #region Html Helper in View:
        // In ASP.NET MVC, HTML Helpers play a crucial role in rendering HTML controls within Razor views.
        // These helpers simplify the process of binding model properties to HTML controls and vice versa.
        // HTML Helpers in ASP.NET MVC are methods that generate HTML markup programmatically.
        // They provide a convenient way to render HTML controls in views based on the model
        //   data.
        // HTML Helpers simplify the process of generating HTML elements with the correct
        //   markup, attributes, and data bindings


        // Purpose: HTML Helpers are used to generate HTML markup dynamically in views.
        // They abstract away the complexities of writing HTML directly in the view templates and
        //   provide a more concise and maintainable way to render HTML controls.


        // Types of HTML Helpers:
        // Built-in HTML Helpers: ASP.NET MVC provides a set of built-in HTML Helpers for
        //   generating common HTML elements, such as form inputs, links, buttons, labels, and more.
        // Custom HTML Helpers: Developers can create custom HTML Helpers to encapsulate reusable
        //   HTML rendering logic.
        // Custom HTML Helpers are especially useful for generating complex or custom HTML elements.


        // Syntax: HTML Helpers are typically invoked in Razor views using the @ symbol followed by
        //   the helper method name.
        // The syntax varies depending on the helper method and its parameters.


        // Example of html helpers and what it is refer to?
        // @Html.TextBox("propName")  =>  <input type="text" id="propName" name="propName" value=""/>
        // @Html.Label("Name")        =>  <label id="Name">Name<label/>
        // @Html.DropDownList("Name") =>  <Select 

        // We have to know that the HTML helper that we used before is a lossly type As it accept the
        //   name of prop as a magic string so there is no auto complete to detect compile error.
        // So we write the name of prop in a wrong way it will not work.
        // Before we move to the strong type let's see how the html helper send data to Action 
        // First the HTML helper search about prop that we write as a string in viewBage, then
        //   ViewData, then it will search about it in Model if the HTML helper find any prop with
        //   the same name it will submit the data to it. if not it will sent null. 


        // Now for the strong type which is better to use as it search about it in Model only 
        //   and it contains auto Complete.
        // @Html.TextBoxFor(model => model.Property)
        // @Html.LabelFor(model => model.Property)
        // @Html.DropDownListFor(model => model.Property, new SelectList(items, "Value", "Text"))

        // As we see here it accepts data as a delegate not as a string, so it will detect errors in
        //   compile time not run time.
        // We have to know to use the strong type Of Html Helper we have to do it inside View with
        //   strong type model or it will not work.

        // The strong Html helper also has another overloads that accepts html code, but it accept it
        //   as a TModel so we have to write it as an object using new keyword.
        // @Html.TextBoxFor(s => s.Name, new{I could write here any html command or css command})
        // @Html.TextBoxFor(s => s.Name, new{style = "color:red; text-align:left;", placeholder="Student Name"})
        // So as we see here we used the style attribute and placeholder which is an HTML code inside
        //   the object to use it inside the HTML helper
        // But we have to know that if we want to use any class of HTML so we can't use the word
        //   class directly as the word class is a word inside c sharp code so we can't use it
        //   directly instead of that we have to put @ before it
        // @Html.TextBoxFor(s => s.Name, new{style = "color:red; text-align:left;", placeholder="Student Name", @class="form-control"})

        // We have some thing with Html helper called Editor for which uses to create an input field
        //   and detect type of this input field depend on type of prop that we deal with so we don't
        //   have to use a specific type for inputs. 
        // Also if you put a data annotation before the prop in model the Editor will see this data
        //   annotation and will take type that used in this data annotations.

        // Also in HTML helper we have another thing called actionLink that used as an anchor tag
        //   which accept to attributes one as a string which is the link text "the text that will
        //   appear in the web page to click on it" and the other is the action name "the method of
        //   Action that you want to go to.

        // The actionLink in HTML helper has seven overloads one of them accepts the link text and
        //   action method name
        // The second accepts link text action method name end control name.
        // The third one accepts link text action method name controller name and attributes if the
        //   action method accepts attributes but we have to know that it accepts attributes as and
        //   object of type t model.
        // The first one accepts link text action method name controller name attributes and HTML
        //   code as an anonymous object of type t model.



        // Model Binding: HTML Helpers are often used in conjunction with model binding to generate
        //   HTML controls bound to model properties.
        // For example, Html.TextBoxFor generates an input element bound to a model property, and
        //   Html.LabelFor generates a label element associated with a model property.


        // IntelliSense Support: HTML Helpers provide IntelliSense support in Razor views, making it
        //   easier to discover available helper methods and their parameters.
        // This helps developers write code more efficiently and with fewer errors.


        // Advantages:
        // Type Safety: HTML Helpers provide type-safe rendering of HTML controls based on the
        //   model's properties, reducing the risk of runtime errors.
        // Consistency: HTML Helpers ensure consistent markup and attribute settings across views,
        //   promoting code maintainability and adherence to design standards.
        // Abstraction: HTML Helpers encapsulate HTML generation logic, making views cleaner and
        //   more focused on presentation logic rather than markup details.



        // Extension Methods: HTML Helpers are implemented as extension methods on the HtmlHelper
        //   class or its derivatives.
        // This allows them to be easily extended and customized to suit specific requirements.

        #endregion

        #region Tag Helper in View:

        // Tag Helpers are a feature introduced in ASP.NET Core MVC that enables server-side code
        //   to participate in the rendering and processing of HTML elements.
        // They provide a more natural and readable way to generate HTML markup compared to
        //   traditional HTML Helpers or inline code blocks.

        // When we use Html helper we don't write any HTML command, but with tag helper we have to
        //   write html command, but with tag helper it will be better to work with prop in models.

        // Purpose: Tag Helpers simplify the process of generating HTML markup by allowing developers
        //   to use HTML-like syntax with server-side functionality.
        // They blend the familiarity of HTML with the power and flexibility of server-side code,
        //   making views more readable and maintainable.


        // Types of Tag Helpers:
        // Built-in Tag Helpers: ASP.NET Core MVC includes a set of built-in Tag Helpers for common
        //   HTML elements, form controls, and other UI components.
        //
        // Custom Tag Helpers: Developers can create custom Tag Helpers to encapsulate reusable HTML
        //   generation logic or to extend the functionality provided by built-in Tag Helpers.


        // Syntax: Tag Helpers are written as HTML-like elements in Razor views, prefixed with
        //   the asp- attribute.
        // The syntax resembles standard HTML attributes but with additional server-side functionality.


        // <input asp-for="Property" />
        // <label asp-for="Property"></label>
        // <select asp-for="Property" asp-items="items"></select>

        // As we see in the previous examples we used a tag helper called asp-for, we have to know
        //   that all tags helpers start with asp-.
        // The asp-for attribute is used to indicate the property depend on the property of model
        // So in the first example we used it with input, and we didn't give this input specific name
        //   or id or type but we use asp-for with specific attribute so this input tag will take its
        //   name, id, and type from this attribute.



        // Model Binding: Like HTML Helpers, Tag Helpers often work with model binding to generate
        //   HTML controls bound to model properties.
        // For example, the asp-for attribute specifies the model property to which the generated
        //   HTML element is bound.



        // IntelliSense Support: Tag Helpers provide IntelliSense support in Razor views, making it
        //   easier to discover available Tag Helpers and their attributes.
        // This helps developers write code more efficiently and with fewer errors.



        // Advantages:
        // Readability: Tag Helpers improve the readability of Razor views by providing a more
        //   natural and HTML-like syntax.
        // Separation of Concerns: Tag Helpers promote separation of concerns by separating HTML
        //   markup from server-side logic, resulting in cleaner and more maintainable views.
        // Flexibility: Tag Helpers offer flexibility and extensibility, allowing developers to
        //   create custom Tag Helpers to suit specific requirements or integrate with third-party libraries.


        // Extension and Customization: Tag Helpers can be extended and customized by creating custom
        //   Tag Helper classes.
        // Developers can define their own Tag Helper classes and attributes to encapsulate reusable
        //   HTML generation logic or to extend the functionality provided by built-in Tag Helpers.



        // Now let's move to the part of tags helper that will be used for each Html tag.


        // Anchor Tag Helper (<a asp-*>):
        // asp-controller: Specifies the controller name for the target action.
        // asp-action: Specifies the action name within the controller.
        // asp-route-*: Allows passing route parameters to the target action.
        // <a asp-controller="Home" asp-action="Details" asp-route-id="123">Details</a>



        // Form Tag Helper (<form asp-*>):
        // asp-controller: Specifies the controller name handling the form submission.
        // asp-action: Specifies the action name within the controller handling the form submission.
        // asp-route-*: Allows passing route parameters to the target action.
        // asp-antiforgery= "true": Generates an anti-forgery token in the form.
        // <form asp-controller="Account" asp-action="Login" method="post">
        //    <!-- Form fields -->
        // </form>




        // Input Tag Helpers (<input asp-*>):
        // asp-for: Binds the input field to a model property.
        // asp-placeholder: Specifies a placeholder text for the input field.
        // asp-for="PropertyName": Generates an input field bound to the specified model property.
        // <input asp-for="UserName" />



        // Label Tag Helper (<label asp-*>):
        // asp-for: Specifies the model property to which the label is associated.
        // <label asp-for="UserName"></label>



        // Select Tag Helper (<select asp-*>):
        // asp-for: Binds the select element to a model property.
        // asp-items: Specifies a collection of SelectListItem objects to populate the select options.
        // asp-items= "Model.PropertyName": Binds the select options to the specified model property.
        // <select asp-for="CountryId" asp-items="Model.Countries"></select>




        // TextArea Tag Helper (<textarea asp-*>):
        // asp-for: Binds the textarea element to a model property.
        // asp-for="PropertyName": Generates a textarea element bound to the specified model property.
        // <textarea asp-for="Description"></textarea>




        // Image Tag Helper (<img asp-*>):
        // asp-src: Specifies the image URL.
        // <img asp-src="~/images/logo.png" />



        // Partial Tag Helper (<partial asp-*>):
        // asp-page: Specifies the Razor Page file to render as a partial view.
        // asp-model: Binds the partial view to a model.
        // <partial asp-page="/Shared/_Footer" />




        #endregion


        #region DataValidation

        // When we work with data that comes from user we have to make sure that this data is valid 
        //   before we save it to database.
        // We have two ways to validate data one for client side validation and  the other for server
        //   side validation.
        // With client side validation we make the validation using JS.
        // But we can't depend on the client side validation as if the user is a programmer or knowing
        //   programming, he might stop the client side validation, So we have to validate all the
        //   data that accepted from client before we save it to database.

        // Server side Validation:
        // First step is to validate properties that accepted from client side before we save it.
        //   this could happen using Data Annotation for model properties.
        // As When we create a model property we have to put all the validation for these properties
        //   as data annotations attributes.
        // To see this data annotation validation go to any model.
        // Now after we add data annotation to validate data for each model property we need now to
        //   know when the server side checks all this validation?

        // We have to know the checks process happen in the post method not in the get method as we
        //   said before the get method is responsible for just opening the form for user, but the
        //   post method accepts data from user and saves it to database.
        // So We have to make sure that the post method will validate data.
        // It will be so boring if we validate every property by an if statement, and this doesn't
        //   make sense because it will take a long time, So micro soft provide a property in
        //   Controller base class called ModelState

        #region ModelState 
        // In ASP.NET MVC, the ModelState property in the controller is used to manage the state of
        //   model objects and to communicate validation errors back to the view. It is an instance of
        //   the ModelStateDictionary class, which stores information about model binding, validation
        //   errors, and the state of model properties.
        // Here's a detailed explanation of the ModelState property and its usage in a controller:

        // Purpose: The primary purpose of the ModelState property is to provide a way to validate and
        //   manage the state of model objects during HTTP request processing.


        // ModelStateDictionary: The ModelState property is of type ModelStateDictionary, which is a
        //   dictionary-like collection that stores key-value pairs of model property names and
        //   associated state information, such as validation errors.


        // Validation Errors: When model binding or validation fails during request processing,
        //   validation errors can be added to the ModelState property using the
        //   ModelState.AddModelError() method. These errors are typically displayed to the user in
        //   the view to provide feedback on invalid input.
        // ModelState.AddModelError("PropertyName", "Error message");


        // Accessing ModelState in Views: In views, you can access the ModelState property to display
        //   validation errors or other information about the state of model properties.
        // For example, you can use the Html.ValidationMessageFor helper method to display validation
        //   errors for a specific model property.
        // @Html.ValidationMessageFor(model => model.PropertyName)


        // Checking ModelState Validity: You can check the overall validity of the ModelState using
        //   the ModelState.IsValid property.
        // This property returns true if no validation errors are present, indicating that the model
        //   is in a valid state and can be processed further.
        // if (ModelState.IsValid)
        //  {
        //      Process the valid model
        //  }


        // Clearing ModelState: You can clear the ModelState using the ModelState.Clear method.
        // This is useful when you want to reset the state of the model before performing additional operations.
        // ModelState.Clear();



        // ModelState Errors Handling: You can handle errors in the ModelState property by checking
        //   its validity and displaying validation errors in the view.
        // This helps provide a user-friendly experience by informing users about invalid input and
        //   guiding them to correct it.
        #endregion

        // So As we know now we don't have to check the validity of the properties using if statements
        //   for each property, As if we used just one if statement for ModelState the modelState will
        //   check the validity for all properties in the accepting model.
        // We have to know that the modelState checks the dataAnnotations before each property in model.
        // So know we could use the Edit or create methods like:
        public IActionResult EditTest(int Id)
        {
            Student student = _context.Students.FirstOrDefault(s => s.Id == Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult EditTest(Student student)
        {
            // here we check if model state in valid
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("GetAll");
            }
            else
            {
                return RedirectToAction("EditTest", student.Id);
            }
        }

        // Or We could also add messages that could appear to user when model state in not valid 
        public IActionResult EditTest2(int Id)
        {
            Student student = _context.Students.FirstOrDefault(s => s.Id == Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult EditTest2(Student student)
        {
            // here we check if model state in not valid
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Failed", "The Editing didn't success");
                  return RedirectToAction("EditTest2", student.Id);
            }
            else
            {

                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("GetAll");
            }
        }
        // We have to know that for each attribute in data annotations there is a default error message.
        // This error message could be used to display the error message for user.
        // Also we could override the default error message to change it if we want
        // [Required(ErrorMessage =("this filed is Required"))]
        // using the Error Message attribute we could change the default error message.
        // using the Error Message attribute we could change the default error message.


        // Now the second step is to go to view and use asp-validation-for attribute to display the
        //   error message.


        // Now what about if I want to make a client side Validation?
        // before we using tag helpers we need to make a JS validation for each field in form that
        //   the use must fill, but now after using tag helpers we have an asp-for=ModelAttribute in tag
        //   helpers and we said before this attribute will be replaced by id, name, value and data
        //   type for this ModelAttribute.
        // Also we have to know that all the data annotations that used to validate data in model 
        //   could be added to client side validation using a JQuery validation in client side.

        // In all MVC projects we have a jquery-validation-unobtrusive library that could understand 
        //   data annotations but we have first to add it to View to use this library
        // Also we have to know that this library needs another library called jquery-validation
        //   which also need another library called jquery to work.
        // So If I want to add the data annotations validate in client side then we need to use these
        //   three libraries in View, and this happens by adding script tag.


        // Now what about if I want to add a custom validation?
        // So as We know the data annotation used as a server side validation which contain some
        //   built-in validation attributes like Required, MinLength, MaxLength, RegularExpression
        //   AllowNull, and so on.
        // But we have to know that not all validation could be found as a built-in data annotation
        //   attributes so we could make our own data annotation by create a new attribute that could
        //   be used as a data annotation attribute
        // To do this we have to make a new class with name end with attribute keyword and this class
        //   must inherit ValidationAttribute class.
        // The validationAttribute class contains a method called IsValid() which contains the logic
        //   to check the validation of the attribute that this data and patient will be used with.

        // So go to Model.UniqueAttribute class to see this custom data annotation attribute.





        // All the points that we already talked about are validation using data annotations which
        //   mean this is a server-side validation, that means The user have to submit his data to
        //   check it. 
        // We used the asp-validation-for attribute in the View to make this server validation work
        //   also with client side.
        // As we see before not all the validation that may I will need are built-in data annotations
        //   so we learned how to create out own validation annotations attributes, but there is
        //   another way that is used as a server validation but now it will be also work in client
        //   side when the data changes not only when it submitted.
        // This called Remote
        // The best feature in Remote is the user doesn't have to submit data to check if it valid or not.
        // Also it works without attributes which mean it works depend on the logic that you want it
        //   to work on, so you have to make a method that contains the logic of checking and use
        //   this method to validate data.



        #region Remote Validation

        // Remote validation is a feature in ASP.NET MVC that allows you to perform server-side
        //   validation asynchronously without submitting the entire form to the server.
        // It's useful when you need to validate a field based on some conditions that require
        //   server-side processing, such as checking if a username or email already exists in the
        //   database.

        // Here's a step-by-step guide on how to implement remote validation in ASP.NET MVC:

        // 1.Create a Validation Action:
        // First, you need to create an action method in your controller that will handle the
        //   validation request.
        // This action should return a JSON result indicating whether the field is valid or not.
        /*
           public IActionResult IsUsernameAvailable(string username)
            {
                // Check if the username is available (e.g., check against the database)
                bool isAvailable = !userRepository.UsernameExists(username);

                return Json(isAvailable);
            }

         */

        // 2.Define Remote Validation Attribute:
        // Use the Remote attribute on your model property to specify the validation action method
        //   and controller.
        /*
            [Remote(action: "IsUsernameAvailable", controller: "Account")]
            public string Username { get; set; }
         */


        // 3.Add Remote Validation Script:
        // Ensure that you have included the necessary jQuery validation and validation Unobtrusive
        //   JavaScript files in your view.


        // 4.Display Validation Error Message:
        // In your view, include the necessary HTML elements to display the validation error message.
        //  <span asp-validation-for="Username" class="text-danger"></span>

        // With these steps, when a user enters a value in the Username field, the remote validation
        //   will trigger an asynchronous call to the server to check if the username is available.
        // If the username already exists, an error message will be displayed without submitting the
        //   form to the server.

        

        // Now lets test this with out Student class.
        public IActionResult chStudentNameExist(string name)
        {
            // We will check if the Student name is already exists in data base or not.
            // If it exists it will return false else it will return true.
            return !_context.Students.Any(s => s.Name == name)? Json(true):Json(false);
        }
        // Now after we create the logic of validation we have to go to Student model and add the
        //   Remote Attribute with Name of Student prop.
        // The Remote method has multiple overloads:
        // One of them accepts The name of Action method that contains logic for validation and the
        //   Name of controller.
        // [Remote(action: "chStudentNameExist", controller:"Student")]
        // This Remote attribute will be above the student name
        // In this attribute will write that the Action is chStudentNameExist, and the controller is
        //   Student, So we have to know that this action method must accept a variable of type same
        //   as the prop that it used for validate it.


        // We have to know we could make a Validation depend on two prop not only one this could
        //   happen if we used the Remote overload that accepts with Action method and controller
        //   name, the AdditionalFields which could be used to pass an additional filed to validation
        //   method, but in this case the Validation method must accepts two variables or more depend
        //   on the number of additional fields.


        #endregion



        #endregion

        #region Partial View
        // Partial views in ASP.NET MVC are reusable components that allow you to break down complex
        //   views into smaller, more manageable components.
        // They can be used to encapsulate sections of markup and logic that are reused across
        //   multiple views or to organize code in a more modular and maintainable way.

        //   Here's how you can create and use partial views in ASP.NET MVC:

        // 1.Creating a Partial View:
        // Create a new .cshtml file in the Views/Shared directory(or any other directory within the
        //   Views folder) and add the markup you want to reuse.
        // This file represents your partial view.


        // 2.Rendering a Partial View:
        // You can render a partial view in your main view by using the Html.Partial or
        //   Html.RenderPartial helper methods.
        // We have two ways to render partial View 
        // 1.Using html helper: As we know that html helper could be used with dot net framework, and
        //   dot net framework core then we could use the html helper with both the new and old projects.
        // with html helper we could use any way of the following:
        // @Html.Partial("NameOfPatialViwe")
        // @Html.PartialAsync("NameOfPatialViwe")
        // @{Html.RenderPartial("NameOfPatialViwe")}
        // @Html.RenderPartialAsync("NameOfPatialViwe")

        // These are four ways to use the html helper to add partial view, but if we look to the third
        //   way we have to know that with RenderPartial() method we have to use curl braces with it
        //   as this method return Void, so it must be used with Curl braces.

        // Also it's better to use the Async method not the others.


        // 2.Using tag helper: As we know that the tag helper used only with dot net framework core,
        //   so it would be better if we used it with the new projects.
        // With tag helper we could use the <partial> tag.
        //<partial name="NameOfPatialViwe" model="ModelName"/>
        // As we can see this example of code we have to know that partial has some attributes:
        //  name: which accepts the name of PatialViwe.
        //  model: this could be used if the partial has a strong type, which means if the partial
        //   View accepts a specific model.



        // Passing Model to Partial View:
        // You can also pass a model to a partial view using the @model directive and render it within
        //   the partial view.

        // Now if we back again to the Html helper how we could pass the model to a partial view?
        // We could this using the same methods but adding the model to this methods.
        // Partial View with Model Data:
        // When rendering a partial view with model data, you can pass the model explicitly using the
        //   Html.Partial method.
        // @Html.Partial("_PartialView", model)



        // Using @Html.RenderPartial:
        // Html.RenderPartial is similar to Html.Partial, but it directly writes the result to the
        //   output stream instead of returning it as a string.
        // It's useful when you want to include a partial view but don't need to capture its output.
        #endregion


        // Now after We did all the above action methods, if we looked back to them we would find that
        //   there are some repeating for some of the queries like firstOrDefault to get the a record
        //   form Data base depend on his Id, or we will find ToList() to get all the records from
        //   data base and more.., also we will find that for all the other controller we have to
        //   repeat all these query to access data base and get or update or delete a record from DB.
        // To avoid the Repeating we have to use The DRY Design pattern.
        // DRY ==> Don't repeat yourself.
        // Dependence injection or Repository Pattern both of them apply the DRY pattern.


        #region Repository Pattern
        // In this extensive guide, we will go through everything you will need to know about
        //   Repository Pattern in ASP.NET Core, Generic Repository Patterns, Unit of Work and
        //   related topics.
        // We will build a project right from scratch where we implement a clean architecture to
        //   access data.


        // What’s a Repository Pattern?
        // A Repository pattern is a design pattern that mediates data from and to the Domain and
        //   Data Access Layers(like Entity Framework Core / Dapper).
        // Repositories are classes that hide the logics required to store or retrieve data.
        // Thus, our application will not care about what kind of ORM we are using, as everything
        //   related to the ORM is handled within a repository layer.
        // This allows you to have a cleaner separation of concerns.
        // Repository pattern is one of the heavily used Design Patterns to build cleaner solutions.
        // So we use Repository pattern to avoid the redundancy of code and also to add a layer to
        //   deal with data base and avoid dealing with data base through controllers.


        // Benefits of Repository Pattern:
        // 1.Reduces Duplicate Queries.
        //   Imagine having to write lines of code to just fetch some data from your dataStore.
        //   Now what if this set of queries are going to be used in multiple places in the application.
        //   Not very ideal to write this code over and over again, right?
        //   Here is the added advantage of Repository Classes.
        //   You could write your data access code within the Repository and call it from multiple
        //     Controllers / Libraries.

        // 2.De-couples the application from the Data Access Layer
        //   There are quite a lot of ORMs available for ASP.NET Core.
        //   Currently the most popular one is Entity Framework Core, But that change in the upcoming years.
        //   To keep in pace with the evolving technologies and to keep our Solutions up to date, it
        //     is highly crucial to build applications that can switch over to a new
        //     DataAccessTechnology with minimal impact on our application’s code base.
        //   There can be also cases where you need to use multiple ORMs in a single solution.
        //   Probably Dapper to fetch the data and EFCore to write the data.
        //   This is solely for performance optimizations.
        //   Repository pattern helps us to achieve this by creating an Abstraction over the
        //     DataAccess Layer.
        //   Now, you no longer have to depend on EFCore or any other ORM for your application.
        //   EFCore becomes one of your options rather than your only option to access data.

        // Building an Enterprise level ASP.NET Core Application would really need Repository Patterns
        //   to keep the codebase future proof for atleast the next 20-25 years (After which, probably
        //   the robots would take over 😛 ).


        // Is Repository Pattern Dead?
        // This is one of the most debated topics within the.NET Core Community.
        // Microsoft has built the Entity Framework Core using the Repository Pattern and Unit of
        //   Work Patterns.So, why do we need to add another layer of abstraction over the Entity
        //   Framework Core, which is yet another abstraction of Data Access.
        // The answer to this is also given by Microsoft.
        // The Entity Framework DbContext class is based on the Unit of Work and Repository patterns
        //   and can be used directly from your code, such as from an ASP.NET Core MVC controller.
        // The Unit of Work and Repository patterns result in the simplest code, as in the CRUD
        //   catalog microserThe Entity Framework DbContext class is based on the Unit of Work and
        //   Repository patterns and can be used directly from your code, such as from an ASP.NET Core
        //   MVC controller.
        // The Unit of Work and Repository patterns result in the simplest code, as in the CRUD
        //   catalog micro-service in eShopOnContainers.
        // In cases where you want the simplest code possible, you might want to directly use the
        //   DbContext class, as many developers do.
        // However, implementing custom repositories provides several benefits when implementing more
        //   complex microservices or applications.
        // The Unit of Work and Repository patterns are intended to encapsulate the infrastructure
        //   persistence layer so it is decoupled from the application and domain-model layers.
        // Implementing these patterns can facilitate the use of mock repositories simulating access
        //   to the database.

        // Using a custom repository adds an abstraction layer that can be used to ease testing by
        //   mocking the repository.
        // There are multiple alternatives when mocking.
        // You could mock just repositories or you could mock a whole unit of work.
        // Usually mocking just the repositories is enough, and the complexity to abstract and mock a
        //   whole unit of work is usually not needed.

        // Microsoft themselves recommend using Repository Patterns in complex scenarios to reduce the
        //   coupling and provide better Testability of your solutions.
        // In cases where you want the simplest possible code, you would want to avoid the Repository Pattern.


        // Let’s implement Repository Pattern in an ASP.NET Core WebApi Project.
        // What seperates this guide from the others is that we will also be working with a Clean
        //   Architecture in mind to demonstrate the real-life implementation.
        // This means that we will be working with multiple Layers and Projects and also go through
        //   the basics of Dependency Inversion Principle.

        // Let’s add 2 more .NET Core Class Library Projects within the solution.
        // We will call it DataAccess.EFCore and Model. Here are the features and purposes of each project.
        // Model – Holds the Entities(Models) and (ViewModels), and Interfaces for repositories.
        //   It does not depend on any other project in the solution.
        // DataAccess,EFCore – Since we will be using Entity Framework Core – Code First Approach to
        //   interact with our Database, let’s build a project that solely represents everything
        //   related to EFCore.
        // The aim is that, later down the road one can easily build another Data Access layer like
        //   DataAccess.Dapper or so.
        // And our application would still support it.Here is where Dependency Inversion comes to play.
        // DataAccess library will contain the ApplicationDbContext and Migration, and implementations
        //   for the repositories Interfaces Which inside Model. 

        // Now after creating these Libraries we will add the Migration and ApplicationDbContext to
        //   DataAccess, and we will add Model and ViewModel to Model.

        // The next step is to make a folder in Learning.Model Library with name IRepository this
        //   folder will contain all the Interfaces for each model and the functions that will be
        //   inside each Interface.

        // Now that we have configured our EFCore Layer, let’s talk a bit about the traditional way to
        //   get data from this layer.
        // Traditionally, you would directly call the dbContext object to read and write data.
        // This is fine. But is it really ideal for the long run?
        // When you use the dbContext directly, what you are doing is that, the Entity Framework Core
        //   is being tightly coupled within your application.
        // So, Tomorrow when there is something newer and better than EFCore, you would find it really
        //   annoying to implement the new tech and make the corresponding changes. Right?
        // One more disadvantage of directly using the dbContext directly is that you would be exposing
        //   the DbContext, which is totally insecure.
        // This is the reason to use Repository Pattern in ASP.NET Core Applications.

        // Practical Use-Case of Repositories:
        // While Performing CRUD Operations with Entity Framework Core, you might have noticed that the
        //   basic essence of the code keeps the same.
        // Yet we write it multiple times over and over.
        // The CRUD Operations include Create, Read, Update, and Delete.
        // So, why not have a class/interface setup where you can generalize each of these operations.

        // As we know that all the models have some shard operations CRUD operations.
        // C ==> Create. 
        // R ==> Read.
        // U ==> Update.
        // D ==> Delete.
        // So It will be better If we make an interface that contains all theses operations except
        //   update, as each model has its own way to update.

        // First up, let’s add a new folder Interfaces in our Model Project. Why?
        // Because, we will be inverting the dependencies, so that, you can define the interface in
        //   the Model Project, but the implementation can be outside the Domain Project.
        // In this case, the implementations will go the DataAccess.EFCore Project.
        // Thus, your Model layer will not depends on anything, rather, the other layers tend to
        //   depend on the Model Layer’s interface.
        // This is a simple explanation of Dependency Inversion Principle. Pretty Cool, yeah?

        // This will be a Generic Interface, that can be used for both the Developer and Project
        //   Classes. Here T is the specific class.
        /*
         public interface IGenericRepository<T> where T : class
         {
            T GetById(int id);
            IEnumerable<T> GetAll();
            IEnumerable<T> Find(Expression<Func<T, bool>> expression);
            void Add(T entity);
            void AddRange(IEnumerable<T> entities);
            void Remove(T entity);
            void RemoveRange(IEnumerable<T> entities);
         }
         */

        // The set of functions depends on your preference.Ideally, we require 7 functions that cover
        //   most of the data handling part.
        // Get’s the entity By Id.
        // Get’s all the Record.
        // Finds a set of record that matches the passed expression.
        // Adds a new record to the context
        // Add a list of records
        // Removes a record from the context
        // Removes a list of records.

        // Now, Let’s implement this Interfaces. Create a new class in the DataAccess.EFCore Project and name it Repositories/GenericRepository
        /*
        public class Repository<T> : IRepository<T> where T : class
        {
            protected readonly ApplicationContext _context;
            public Repository(ApplicationContext context)
            {
                _context = context;
            }
            public void Add(T entity)
            {
                _context.Set<T>().Add(entity);
            }
            public void AddRange(IEnumerable<T> entities)
            {
                _context.Set<T>().AddRange(entities);
            }
            public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
            {
                return _context.Set<T>().Where(expression);
            }
            public IEnumerable<T> GetAll()
            {
                return _context.Set<T>().ToList();
            }
            public T GetById(int id)
            {
                return _context.Set<T>().Find(id);
            }
            public void Remove(T entity)
            {
                _context.Set<T>().Remove(entity);
            }
            public void RemoveRange(IEnumerable<T> entities)
            {
                _context.Set<T>().RemoveRange(entities);
            }
        }
        */

        // Now, Let’s implement this Interfaces. Create a new class in the DataAccess layer and name it
        //   Repositories/GenericRepository

        // This class will implement the IGenericRepository Interface.
        // We will also inject the ApplicationContext here.
        // This way we are hiding all the actions related to the dbContext object within Repository Classes.
        // Also note that, for the ADD and Remove Functions, we just do the operation on the dbContext object.
        // But we are not yet committing/updating/saving the changes to the database whatever.
        // This is not something to be done in a Repository Class.
        // We would need Unit of Work Pattern for these cases where you commit data to the database.
        // We will discuss about Unit of Work in a later section.

        // Understood why we used a Generic Repository instead of a IDevloperRepository??
        // When there are large number of entities in our application, we would need separate
        //   repositories for each entities.But we do not want to implement all of the above 7
        //   Functions in each and every Repository Class, right? Thus we made a generic repository
        //   that holds the most commonly used implementations.

        // Now what happens if we need the records of Most Popular Student from our Database?
        //   We do not have a function for it in our Generic Class, do we?
        //   This is where we can see the advantage of building a Generic Repository.
        //   This is where we can see the advantage of building a Generic Repository.

        // Inheriting and Extending the Generic Repository
        // In the Domain Project, under the Interfaces, add a new interface named IStudentRepository

        /*
         public interface IStudentRepository : IGenericRepository<Developer>
         {
             IEnumerable<Student> GetPopularStudent(int count);
         }
         */
        // Here we are inheriting all the Functions of the Generic Repository, as well as adding a new
        //   Function ‘GetPopularStudent’. Get it?

        // Let’s implement the IDeveloperRepostory.Go to the DataAccess Project and under Repositories
        //   folder, add a new class, DeveloperRepository.
        /*
         public class StudentRepository : Repository<Developer>, IStudentRepository
         {
            public StudentRepository(ApplicationContext context):base(context)
            {
            }
            public IEnumerable<Student> GetPopularStudent(int count)
            {
                return _context.Student.OrderByDescending(d => d.Followers).Take(count).ToList();
            }
         }
         */
        // You can notice that we have not implemented all the 7 functions here, as it is is already
        //   implemented in our Generic Repository. Saves a lot of lines, yeah?

        // You can see that the interface and implementations are quite blank. So why create new class
        //   and interface for Project? This can also attribute to a good practice while developing
        //   applications.
        // We also anticipate that in future, there can be functions that are spcific to the Project
        //   Entity.
        // To support them later on, we provide with interfaces and classes. Future Proofing, yeah?

        // Finally, let’s register these Interfaces to the respective implementations in the Startup.cs
        //  of the WebApi Project. Navigate to Startup.cs/ConfigureServices Method and add these lines.
        /*
          #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
          #endregion
         */
        // Why we have to add these services to startup project file?
        // As we want to achieve the dependency injection protocol(Pattern) to make that there is no
        //   class depend on any other classes, So to do this we have to add services to the project
        //   that define the implementation of each interface in our repository pattern.
        #endregion


        #region Unit Of Work Pattern
        // Now after creating the repository pattern we need to add the Unit Of Work pattern which will
        //   be responsible for saving data to database.

        // Unit of Work Pattern is a design pattern with which you can expose various repositories in
        //   our application.
        // It has very similar properties of dbContext, just that Unit of Work is not coupled to any
        //   framework like dbContext to Entity Framework Core.

        // Till now, we have built a couple of repositories.
        // We can easily inject these repositories to the constructor of the Services classes and
        //  access data.
        // This is quite easy when you have just 2 or 3 repository objects involved.
        // What happens when there are quite more than 3 repositories.
        // It would not be practical to keep adding new injections every new and then.
        // In order to wrap all the Repositories to a Single Object, we use Unit Of Work.

        // Unit of Work is responsible for exposing the available Repositories and to Commit Changes to
        //   the DataSource ensuring a full transaction, without loss of data.

        // The other major advantage is that, multiple repository objects will have different instances
        //   of dbcontext within them.This can lead to data leaks in complex cases.

        // Let’s say that you have a requirement to insert a new Student and a new Course within the
        //   same transaction.What happens when the new Student get’s inserted but the Project
        //   Repository fails for some reason.
        // In real-world scenarios, this is quite fatal.
        // We will need to ensure that both the repositories work well, before committing any change to
        //   the database.
        // This is exactly why we decided to not include SaveChanges in any of the repositories. Clear?

        // Rather, the SaveChanges will be available in the UnitOfWork Class.
        // You will get a better idea once you see the implementation.

        // Let’s get started with the IUnitOfWork.
        // Create a new Interface in the domain Project, Interfaces/IUnitOfWork

        /*
          public interface IUnitOfWork : IDisposable
          {
            IStudentRepository Developers { get; }
            ICourseRepository Projects { get; }
            int Complete();
          }
         */
        // You can see that we are listing the interfaces of the required Repositories within the
        //   UOW Interface.
        // It’s also a Disposable Element.
        // Finally we have a ‘Complete’ Function which will save the changes to the database.
        // Let’s implement this interface. Create the implementation at the DataAccess Project.
        // Add a new class in the UnitOfWork/UnitOfWork.cs
        /*
          public class UnitOfWork : IUnitOfWork
          {
            private readonly ApplicationContext _context;
            public UnitOfWork(ApplicationContext context)
            {
                _context = context;
                Developers = new DeveloperRepository(_context);
                Projects = new ProjectRepository(_context);
            }
            public IDeveloperRepository Developers { get; private set; }
            public IProjectRepository Projects { get; private set; }
            public int Complete()
            {
                return _context.SaveChanges();
            }
            public void Dispose()
            {
                _context.Dispose();
            }
          }
         */
        // We could make the Complete method here of type Void not int.

        // Note that, Here we are injecting a private AppplicationContext.
        // Let’s wire up or controllers with these Repositories.
        // Ideally you would want to have a service layer between the Repository and Controllers.
        // But, to keep things fairly simple, we will avoid the service layer now.
        // Before that, let’s not forget to register the IUnitofWork Interface in our Application.
        // Navigate to Startup.cs/ConfigureServices Method and add this line.
        // services.AddTransient<IUnitOfWork, UnitOfWork>();

        // Now after we have applied the repository and unit of work patterns, we could now use them
        //   inside our controller instead of using ApplicationDbContext directly.
        /*
         public class StudentController : ControllerBase
         {   
            private readonly IUnitOfWork _unitOfWork;
            public StudentController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
         }
         */
        // Here are injecting only the IUnitOfWork object. This way, you can completely avoid writing
        //   lines and lines of injections to your controllers.
        // Now, let’s say we need two endpoints for this controller.A POST and a GET Method.
        // Get all the Popular Student.
        // Insert a new Student and a new Course.

        // We’ll start working on the methods now.
        /*
          public IActionResult GetPopularStudent([FromQuery]int count)
          {
              var popularStudent = _unitOfWork.Student.GetPopularStudent(count);
              return Ok(popularDevelopers);
          }
         */


        /*
         [HttpPost]
        public IActionResult AddDeveloperAndProject()
        {
            var Student = new Developer
            {
                Address = aga,
                Name = "Mukesh Murugan"
            };
            var Course = new Course
            {
                Name = "codewithmukesh"
            };
            _unitOfWork.Student.Add(developer);
            _unitOfWork.Course.Add(project);
            _unitOfWork.Complete();
            return Ok();

        }
         */

        #endregion












    }

}
