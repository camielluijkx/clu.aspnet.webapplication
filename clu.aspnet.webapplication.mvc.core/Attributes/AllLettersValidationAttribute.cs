using clu.aspnet.webapplication.mvc.core.Models;
using clu.aspnet.webapplication.mvc.core.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.Attributes
{
    public class AllLettersValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            return ((string)value).All(Char.IsLetter);
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    Person person = (Person)validationContext.ObjectInstance;

        //    if (!string.IsNullOrEmpty(person.Name) && !person.Name.All(Char.IsLetter))
        //    {
        //        return new ValidationResult("All characters in Name must be letters");
        //    }

        //    return ValidationResult.Success;
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IMyService)validationContext.GetService(typeof(IMyService));

            Person person = (Person)validationContext.ObjectInstance;

            if (!string.IsNullOrEmpty(person.Name) && !person.Name.All(Char.IsLetter))
            {
                return new ValidationResult("All characters in Name must be letters");
            }

            return ValidationResult.Success;
        }
    }
}