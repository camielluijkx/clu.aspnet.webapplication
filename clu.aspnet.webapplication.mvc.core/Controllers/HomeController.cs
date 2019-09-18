using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using clu.aspnet.webapplication.mvc.core.Models;
using clu.aspnet.webapplication.mvc.core.Services;
using System;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class HomeController : Controller
    {
        private IMyService _myService;

        private IRandomService _randomService;
        private IRandomWrapper _randomWrapper;

        #region Example #14

        public IActionResult Index14()
        {
            return Content("Hello from controller");
        }

        #endregion

        #region Example #15

        //public HomeController(IMyService myService)
        //{
        //    _myService = myService;
        //}

        public IActionResult Index15()
        {
            return Content(_myService.ReturnSomething());
        }

        #endregion

        #region Example #16

        //public HomeController(IRandomService randomService, IRandomWrapper randomWrapper)
        //{
        //    _randomService = randomService;
        //    _randomWrapper = randomWrapper;
        //}

        public IActionResult Index16()
        {
            string result = $"The number from service in controller: { _randomService.GetNumber()}, the number from wrapper service: { _randomWrapper.GetNumber()}";

            return Content(result);
        }

        #endregion

        #region Example #17

        //public HomeController(IRandomService randomService, IRandomWrapper randomWrapper)
        //{
        //    _randomService = randomService;
        //    _randomWrapper = randomWrapper;
        //}

        public IActionResult Index17()
        {
            string result = $"The number from service in controller: { _randomService.GetNumber()}, the number from wrapper service: { _randomWrapper.GetNumber()}";

            return Content(result);
        }

        #endregion

        #region Example #18

        //public HomeController(IRandomService randomService, IRandomWrapper randomWrapper)
        //{
        //    _randomService = randomService;
        //    _randomWrapper = randomWrapper;
        //}

        public IActionResult Index18()
        {
            string result = $"The number from service in controller: { _randomService.GetNumber()}, the number from wrapper service: { _randomWrapper.GetNumber()}";

            return Content(result);
        }

        #endregion

        #region Example #19

        public ViewResult Index19()
        {
            SimpleModel model = new SimpleModel() { Value = "My Value" };

            return View(model);

            // ViewResult : ActionResult -> IActionResult
        }

        #endregion

        #region Example #20

        public ContentResult Index20()
        {
            return Content("some text");

            // ContentResult : ActionResult
        }

        #endregion

        #region Example #21

        public RedirectToActionResult Index21()
        {
            return RedirectToAction("AnotherAction");

            // RedirectToActionResult : ActionResult
        }

        public ContentResult AnotherAction21()
        {
            return Content("text from another action");
        }

        #endregion

        #region Example #22

        public RedirectToRouteResult Index22()
        {
            return RedirectToRoute(new
            {
                controller = "Another",
                action = "AnotherAction"
            });

            // RedirectToRouteResult : ActionResult
        }

        #endregion

        #region Example #23

        public StatusCodeResult Index23()
        {
            return new StatusCodeResult(404);

            // StatusCodeResult : ActionResult
        }

        #endregion

        #region Example #24

        public IActionResult Index24([FromRoute]string id)
        {
            return Content(id);
        }

        #endregion

        #region Example #25

        public IActionResult Index25()
        {
            string id = (string)RouteData.Values["id"];

            return Content(id);
        }

        #endregion

        #region Example #26

        public IActionResult Index26([FromQuery]string id)
        {
            return Content(id);
        }

        #endregion

        #region Example #27

        public IActionResult Index27()
        {
            ViewBag.Message = "some text";
            ViewBag.ServerTime = DateTime.Now;

            return View();
        }

        #endregion

        #region Example 28

        public IActionResult Index28()
        {
            ViewData["Message"] = "some text"; ViewData["ServerTime"] = DateTime.Now;

            return View();
        }

        #endregion

        public IActionResult Index()
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