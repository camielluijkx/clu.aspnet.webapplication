using System;
using System.ComponentModel.DataAnnotations;

namespace clu.aspnet.webapplication.mvc.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LargerThanValidationAttribute : ValidationAttribute
    {
        public int MinimumValue { get; set; }

        //Constructor
        public LargerThanValidationAttribute(int minimum)
        {
            MinimumValue = minimum;
        }

        //You must override the IsValid method to run your test
        public override Boolean IsValid(Object value)
        {
            var valueToCompare = (int)value;
            if (valueToCompare > MinimumValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}