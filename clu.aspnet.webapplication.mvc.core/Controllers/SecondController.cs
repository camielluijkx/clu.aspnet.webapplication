using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class SecondController : Controller
    {
        [Route("Second/Index")]
        public IActionResult MyAction()
        {
            return Content("Second Controller");
        }
    }
}