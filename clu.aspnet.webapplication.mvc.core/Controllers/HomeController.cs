using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using clu.aspnet.webapplication.mvc.core.Models;
using clu.aspnet.webapplication.mvc.core.Services;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class HomeController : Controller
    {
        private IMyService _myService;

        private IRandomService _randomService;
        private IRandomWrapper _randomWrapper;

        public HomeController(IMyService myService, IRandomService randomService, IRandomWrapper randomWrapper)
        {
            _myService = myService;

            _randomService = randomService;
            _randomWrapper = randomWrapper;
        }

        public IActionResult Index()
        {
            //return Content("Hello from controller");

            //return Content(_myService.ReturnSomething());

            string result = $"The number from service in controller: { _randomService.GetNumber()}, the number from wrapper service: { _randomWrapper.GetNumber()}";

            return Content(result);
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
