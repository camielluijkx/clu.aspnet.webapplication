using clu.aspnet.webapplication.mvc.core.Attributes;
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
        [Required(ErrorMessage = "Please enter a name.")]
        [AllLettersValidation(ErrorMessage = "Only letters allowed.")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [RegularExpression(".+\\@.+\\..+")]
        //[EmailAddress]
        public string EmailAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(20)]
        public string Description { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }
    }
}