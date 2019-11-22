using clu.aspnet.webapplication.mvc.core.api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Produces("application/xml")]
        public IEnumerable<Person> Get()
        {
            List<Person> people = new List<Person>
            {
                new Person() { ID = 1, Name = "Bob" },
                new Person() { ID = 2, Name = "Mike" }
            };

            return people;
        }
    }
}