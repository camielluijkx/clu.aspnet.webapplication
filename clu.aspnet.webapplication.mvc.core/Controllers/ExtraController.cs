using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class ExtraController : Controller
    {
        [Route("SomeRoute")]
        public IActionResult Method1()
        {
            return Content("Method1");
        }

        public IActionResult Method2()
        {
            return Content("Method2");
        }
    }
}