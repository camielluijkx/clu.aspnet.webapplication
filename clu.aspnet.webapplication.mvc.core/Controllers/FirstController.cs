using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class FirstController : Controller
    {
        [Route("First/Some")]
        public IActionResult Some()
        {
            return View();
        }
    }
}