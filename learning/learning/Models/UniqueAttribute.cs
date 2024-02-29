using System;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;

namespace learning.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // When we make a new data invitation attribute class we have to avoid there IsValid()
        //   method that inside the validation attribute class.
        // IsValid() method has two overloads one that accept value as an object and the other
        //   accepts value as an object and validation context class object.
        // The object value that accepted is the property that will use this data annotation attribute
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Department dep = _context.Department.FirstOrDefault(d => d.Name == value.ToString());
            if (dep == null)
            {
                return ValidationResult.Success;
            }
           
                return new ValidationResult("This department already exists");
            
        }

    }
}
