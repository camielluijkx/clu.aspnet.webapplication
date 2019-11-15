using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class CorsController1 : Controller
    {
        [EnableCors("FromContoso")]
        public IActionResult Index()
        {
            return View("index");
        }
    }

    [EnableCors("FromContoso")]
    public class CorsController2 : Controller
    {
        [DisableCors]
        public IActionResult Index()
        {
            return View("index");
        }
    }
}