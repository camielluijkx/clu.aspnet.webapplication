using clu.aspnet.webapplication.mvc.core.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    [Route("Some")] // all the routes in a controller class should start with the same prefix
    [SimpleActionFilter]
    public class MyController : Controller
    {
        public IActionResult SomeMethod()
        {
            return Content("Some method");
        }

        [Route("My/{param}")]
        public IActionResult SomeMethod(string param)
        {
            return Content(param);
        }

        [Route("My/{param1}/{param2:int}")]
        public IActionResult SomeMethod(string param1, int param2)
        {
            return Content("param1: " + param1 + ", param2: " + param2);
        }

        [Route("My/{param1}/{param2?}")]
        public IActionResult SomeMethod(string param1, string param2)
        {
            return Content("param1: " + param1 + ", param2: " + param2);
        }

        [Route("My/Method1")]
        public IActionResult Method1()
        {
            return Content("Method1");
        }

        [Route("My/Method2")]
        public IActionResult Method2()
        {
            return Content("Method2");
        }
    }
}