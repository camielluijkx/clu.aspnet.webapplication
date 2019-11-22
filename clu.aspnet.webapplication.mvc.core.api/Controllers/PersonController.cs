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
        public Person GetBuyId()
        {
            return new Person() { Id = 1, Name = "Mike" };
        }

        [HttpGet]
        //[Produces("application/xml")]
        public IEnumerable<Person> GetAll()
        {
            List<Person> people = new List<Person>
            {
                new Person { Id = 1, Name = "Bob" },
                new Person { Id = 2, Name = "Mike" }
            };

            return people;
        }
    }
}