using Microsoft.EntityFrameworkCore;
using Learning.Model;


namespace  Learning.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        #region Some information about DbContext Class and Connection to database.
        // If we go to the definition of DbContext class we will find that it contains two 
        //   constructors one of them doesn't accept any parameters and the other accept a
        //   parameter of type DbContextOptions.
        // We will find that in the first constructor which accepts nothing it calls the
        //   other constructor and pass a default DbContextOptions, but now what is the
        //   options that passes to the second constructor?
        // The options that passes to the second constructor comes from the OnConfiguring
        //   method in the DbContext class.
        // The OnConfiguring method in the DbContext class accepts a parameter of type
        //   DbContextOptionsBuilder this builder class is responsible for building the
        //   connection to the database.

        // DbContextOptionsBuilder class has a method called UseSqlServer which accepts the connection.

        // The connection of the database must contain the following parameters:

        // DBMS : Database Management System type like MySQL, SQL Server, etc
        // Instance : Which instance to connect to database as may be you have different Instances
        // Authentications : type of authentication as we have different type of it like Windows Authentication or SQL Server authentication .
        // DatabaseName : Name of the database that you want to create or you want to connect to.

        // So if we will work with default Constructor we have to override the OnConfiguring
        //   method to apply the Parameters that accepted to Connection.
        #endregion

        public ApplicationDbContext() : base()
        {
            
        }
        // This ctor used with injection.
        public ApplicationDbContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Data Source : the name of connection server in SQL Server
            // Initial Catalog : The name of the database
            // Integrated Security : The type of Authentication if it try it will use the windows Authentication else you have to enter the userName and password if you have.
            // The others are optional.
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCLearning;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
            // Now after making the connection to database we could know use Entity framework
            //   to add tables to database.
        }


        // We have another method in DBContext called OnModelCreating:
        // This method used to make some operations in tables inside the database like add
        //   some records or update some records, set some fluent APIs.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "SD",
                    ManagerName = "Ahmed"
                },
                new Department
                {
                    Id = 2,
                    Name = "Web",
                    ManagerName = "Emad"
                },
                new Department
                {
                    Id = 3,
                    Name = "Fluter",
                    ManagerName = "Omar"
                }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Saad",
                    Address = "Aga",
                    Dep_Id = 1,
                    Image = "IMG20191207234622.jpg",
                    Salary = 17000
                },
                new Employee
                {
                    Id = 2,
                    Name = "Ahmed",
                    Address = "Cairo",
                    Dep_Id = 2,
                    Image = "IMG20191207235431.jpg",
                    Salary = 13000
                }, new Employee
                {
                    Id = 3,
                    Name = "Ibrahim",
                    Address = "Giza",
                    Dep_Id = 3,
                    Image = "IMG20200316005620",
                    Salary = 16400
                }
                );
        }







        // The DbSet class used to add table to database.
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainers { get; set; }
        public DbSet<CourseResult> CoursesResults { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
