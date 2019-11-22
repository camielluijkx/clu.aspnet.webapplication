using clu.aspnet.webapplication.mvc.core.api.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace clu.aspnet.webapplication.mvc.core.api.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]
    //[Route("api/[controller]/{id}")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string Get()
        {
            return "Response from Web API";

            /*
            
            + [Route("api/[controller]")]
            https://localhost:44337/api/Home

            The request matched multiple endpoints.

            */
        }

        [HttpGet("Some")]
        [AcceptVerbs("Get", "Head")]
        [ActionName("SomeAction")]
        public string SomeMethod()
        {
            return "SomeMethod was invoked";

            /*
            
            + [Route("api/[controller]")]
            + [HttpGet]
            https://localhost:44337/api/Home

            + [Route("api/[controller]")]
            + [AcceptVerbs("Get", "Head")]
            https://localhost:44337/api/Home/Some

            + [Route("api/[controller]/[action]")]
            + [HttpGet("Some")]
            https://localhost:44337/api/Home/SomeMethod

            + [Route("api/[controller]")]
            + [ActionName("SomeAction")]
            https://localhost:44337/api/Home/SomeAction

            */
        }

        [HttpGet("Other")]
        public string OtherMethod()
        {
            return "OtherMethod was invoked";

            /*
            
            + [Route("api/[controller]")]
            + [HttpGet("Other")]
            https://localhost:44337/api/Home/Other
            
            */
        }

        //[HttpGet]
        [HttpGet("{id}")]
        public string GetId(int id)
        {
            if (id >= 0)
            {
                return "Input number is: " + id;
            }

            throw new ArgumentException();

            /*
            
            + [Route("api/[controller]/{id}")]
            + [HttpGet]
            https://localhost:44337/api/Home/1

            + [Route("api/[controller]")]
            + [HttpGet("{id}")]
            https://localhost:44337/api/Home/1

            */
        }

        [HttpGet("{id}/{name}")]
        public string Get(int id, string name)
        {
            if (id >= 0)
            {
                return "id: " + id + ", name: " + name;
            }

            throw new ArgumentException();

            /*
            
            + [Route("api/[controller]")]
            + [HttpGet("{id}/{name}")]
            https://localhost:44337/api/Home/1/Camiel

            */
        }

        [HttpPost]
        public void Post([FromBody]Customer item)
        {

        }
    }
}