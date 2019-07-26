using clu.aspnet.webapplication.mvc.net.Attributes;

namespace clu.aspnet.webapplication.mvc.net.Models
{
    public class Person
    {
        [LargerThanValidation(18)]
        public int VoterAge { get; set; }
    }
}