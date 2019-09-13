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

        private IActionResult runControllerExample1()
        {
            return Content("Hello from controller");

            //https://localhost:44395                       : Hello from controller
            //https://localhost:44395/Home                  : Hello from controller
            //https://localhost:44395/Home/Index            : Hello from controller
        }

        private IActionResult runControllerExample2()
        {
            return Content(_myService.ReturnSomething());

            //https://localhost:44395                       : Hello World!
            //https://localhost:44395/Home                  : Hello World!
            //https://localhost:44395/Home/Index            : Hello World!
        }

        private IActionResult runControllerExample3()
        {
            string result = $"The number from service in controller: { _randomService.GetNumber()}, the number from wrapper service: { _randomWrapper.GetNumber()}";

            return Content(result);

            //https://localhost:44395                       : The number from service in controller: x, the number from wrapper service: x/y
            //https://localhost:44395/Home                  : The number from service in controller: x, the number from wrapper service: x/y
            //https://localhost:44395/Home/Index            : The number from service in controller: x, the number from wrapper service: x/y
        }

        public HomeController(IMyService myService, IRandomService randomService, IRandomWrapper randomWrapper)
        {
            _myService = myService;

            _randomService = randomService;
            _randomWrapper = randomWrapper;
        }

        public IActionResult Index()
        {
            //return runControllerExample1();
            //return runControllerExample2();
            return runControllerExample3();
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