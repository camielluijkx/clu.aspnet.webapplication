using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using clu.aspnet.webapplication.mvc.core.Models;
using clu.aspnet.webapplication.mvc.core.Services;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class HomeController : Controller
    {
        private IMyService _myService;

        public HomeController(IMyService myService)
        {
            _myService = myService;
        }

        public IActionResult Index()
        {
            //return Content("Hello from controller");

            return Content(_myService.ReturnSomething());
        }

        public IActionResult Index_()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
