using Azure;
using Learning.Model.IRepository;
using Learning.DataAccess.Repository;
using Microsoft.Identity.Client;
using System.Runtime.Intrinsics.X86;
using Learning.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace learning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // To Apply Dependency injection we need to add all services here.
            // We have tree type of services:
            // 1. Build-in services that already registered In IOC Container 
            // 2. Build-in services but not registered in IOC Container, and you could add it if you need like addSession or addDBContext
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCLearning;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            });// This is a way to configure data base connection, but it's not the best way when we
               // dealing with servers, the best way is to put connection of server or data base in
               // Appsetting.jason file.
            // Now after adding Connection string in AppSetting file then we could add this configure
            //   here.
            builder.Services.AddDbContext<ApplicationDbContext>( option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }); // This way is better as we could change the connection string to data base just in appsettings file.

            builder.Services.AddControllersWithViews();
          

            builder.Services.AddSession();// If we used it like this this mean it will take the
                                          //  default session settings which is the life time is
                                          //  20 minutes, but we could change it by adding
                                          //  another delegate refer to the new session
                                          //  implementation
            builder.Services.AddSession(conf =>
            {
                conf.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            // We have three ways to add or inject a service in our Application:
            // 1. Using AddScope: This will create one object per Request.
            // 2. Using AddTransient: This will create one object per inject even if they are in the
            //     same request.
            // 3. Using AddSingleton: This will create one object for all the services and requests and
            //     also for all users, and this object will not distorted until the server stops.
           
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  
            var app = builder.Build();



        #region Middlewares and Pipeline.
        // To get more information about the pipeline and Middlewares visit:
        // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0

        // Middleware is software that's assembled into an app pipeline to handle requests
        //   and responses.
        // Each component:
        // Chooses whether to pass the request to the next component in the pipeline.
        // Can perform work before and after the next component in the pipeline.

        // Request delegates are configured using Run, Map, and Use extension methods.
        // An individual request delegate can be specified in-line(Which mean if you
        //   customize your Pipeline(Middleware) then you will use Delegates and give it the
        //   definition in the same line) as an anonymous method
        //   (called in-line middleware), or it can be defined in a reusable class.
        // These reusable classes and in-line anonymous methods are middleware, also called
        //   middleware components.
        // Each middleware component in the request pipeline is responsible for invoking
        //   the next component in the pipeline or short-circuiting the pipeline.
        // If the middleware name starts with use this mean it may be call the next pipeline
        //   method, but if it start with run this means it will terminate the pipeline request.
        // When a middleware short-circuits, it's called a terminal middleware because it
        //   prevents further middleware from processing the request.


        // We have to know the order of the middleware is important as:
        // Each delegate can perform operations before and after the next delegate.
        // Exception-handling delegates should be called early in the pipeline, so they can
        //   catch exceptions that occur in later stages of the pipeline.


        // We have three type of middleware build in, custom, and nuget package middleware.

        // If we want to make a custom middleware we could use "use" or "run" key words.
        // The simplest possible ASP.NET Core app sets up a single request delegate that
        //   handles all requests.
        // This case doesn't include an actual request pipeline. Instead, a single anonymous
        //   function is called in response to every HTTP request.
        // var builder = WebApplication.CreateBuilder(args);
        /*

        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hello world!");
        });

        */
        // As we see in the example above we used the run which will terminate the request '
        //  pipeline after it invoked.


        // If we want to Chain multiple request delegates together we have to use the keyword "Use".
        // The next parameter represents the next delegate in the pipeline.
        // You can short-circuit the pipeline by not calling the next parameter.
        // You can typically perform actions both before and after the next delegate, as the
        //   following example demonstrates:
        /*

        app.Use(async (context, next) =>
        {
            // Do work that can write to the Response.
            await context.Response.WriteAsync("Hello from 1st delegate.");
            await next.Invoke();
            // Do logging or other work that doesn't write to the Response.
        });

        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hello from 2nd delegate.");
        });

        */
        // As we see int the example above we used a delegate Use and we passed two
        //   parameters one for the context and the other one for the next delegate to call
        //   it this called Chaining.
        // As we also see in the second delegate we didn't pass a next pipeline so this
        //   delegate we case a short circuit.


        // Short-circuiting the request pipeline:
        // When a delegate doesn't pass a request to the next delegate, it's called
        //   short-circuiting the request pipeline.
        // Short - circuiting is often desirable because it avoids unnecessary work.
        // For example, Static File Middleware can act as a terminal middleware by
        //   processing a request for a static file and short-circuiting the rest of the pipeline.
        // Middleware added to the pipeline before the middleware that terminates further
        //   processing still processes code after their next.Invoke statements.



        // Run delegates:
        // Run delegates don't receive a next parameter.
        // The first Run delegate is always terminal and terminates the pipeline.
        // Run is a convention.
        // Some middleware components may expose Run[Middleware] methods that run at the end of the pipeline:
        /*

        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hello from 2nd delegate.");
        });

        */

        // The following image describes the order of middleware.
        // wwwroot\Images\OrderOfMiddelWare\MiddelWareOrder.png



            #endregion


            // the build in Middleware.
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            // The pipeline of session will be after routing and Authorization.
            app.UseSession();
            // but it's not enough to add pipeline and use session without adding its services 
            // To add it we have to go above with builder service and it its services.
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
            
            app.Run();
        }
    }
}
