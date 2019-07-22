using clu.aspnet.webapplication.mvc.Attributes;

namespace clu.aspnet.webapplication.mvc.Models
{
    public class Person
    {
        [LargerThanValidationAttribute(18)]
        public int VoterAge { get; set; }
    }
}