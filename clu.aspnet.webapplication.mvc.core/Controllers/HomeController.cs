using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using clu.aspnet.webapplication.mvc.core.Models;
using clu.aspnet.webapplication.mvc.core.Services;
using System;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class HomeController : Controller
    {
        const int CALL_INDEX = 1000;
        const int INVALID_DIVISION = 9006;

        private IMyService _myService;

        private IRandomService _randomService;
        private IRandomWrapper _randomWrapper;

        private ILogger _logger;

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

        #region Example #28

        public IActionResult Index28()
        {
            ViewData["Message"] = "some text"; ViewData["ServerTime"] = DateTime.Now;

            return View();
        }

        #endregion

        #region Example #63

        public IActionResult Index63()
        {
            return View();
        }

        #endregion

        #region Example #64

        public ViewResult Index64()
        {
            SimpleModel model = new SimpleModel() { Value = "My Value" };

            return View(model);
        }

        #endregion

        #region Example #65

        public ViewResult Index65()
        {
            ViewBag.Message = "message";

            return View();
        }

        #endregion

        #region Example #68

        public IActionResult InvokeVC68()
        {
            return ViewComponent("My");

            //https://localhost:44395/Home/InvokeVC         : Id: 6
        }

        #endregion

        #region Example #71

        public IActionResult InvokeVC71()
        {
            return ViewComponent("My", new { param = 7 });

            //https://localhost:44395/Home/InvokeVC         : Id: 7
        }

        #endregion

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation(CALL_INDEX, "Adding an entry to the logger.");

            return View();
        }

        public IActionResult Division()
        {
            try
            {
                int x = 3;
                x -= 3;

                int result = 30 / x;
            }
            catch (Exception ex)
            {
                _logger.LogError(INVALID_DIVISION, ex, "An error occurred while dividing!");
            }

            return Content("Result from controller");
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