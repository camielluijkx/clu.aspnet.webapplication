using System;
using System.ComponentModel.DataAnnotations;

namespace clu.aspnet.webapplication.mvc.core.Models
{
    public class Person
    {
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Display(Name = "Contact me? ")]
        public bool ContactMe { get; set; }

        [Display(Name = "My Name")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}