using clu.aspnet.webapplication.mvc.Attributes;

namespace clu.aspnet.webapplication.mvc.Models
{
    public class Person
    {
        [LargerThanValidation(18)]
        public int VoterAge { get; set; }
    }
}