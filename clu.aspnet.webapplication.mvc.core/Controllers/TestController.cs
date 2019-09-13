using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class TestController : Controller
    {
        private IActionResult runControllerExample1()
        {
            SimpleModel model = new SimpleModel() { Value = "My Value" };

            return View(model);

            //https://localhost:44395/Test                  : My Value
            //https://localhost:44395/Test/Fake             : Page not found
            //https://localhost:44395/Test/Index            : My Value
        }

        private ViewResult runControllerExample2()
        {
            SimpleModel model = new SimpleModel() { Value = "My Value" };

            return View(model);

            // ViewResult : ActionResult -> IActionResult
        }

        private ContentResult runControllerExample3()
        {
            return Content("some text");

            // ContentResult : ActionResult
        }

        private RedirectToActionResult runControllerExample4()
        {
            return RedirectToAction("AnotherAction");

            // RedirectToActionResult : ActionResult
        }

        public RedirectToRouteResult runControllerExample5()
        {
            return RedirectToRoute(new
            {
                controller = "Another",
                action = "AnotherAction"
            });

            // RedirectToRouteResult : ActionResult
        }

        public StatusCodeResult runControllerExample6()
        {
            return new StatusCodeResult(404);

            // StatusCodeResult : ActionResult
        }

        public IActionResult Index()
        {
            //return runControllerExample1();
            //return runControllerExample2();
            //return runControllerExample3();
            //return runControllerExample4();
            //return runControllerExample5();
            return runControllerExample6();
        }

        public ContentResult AnotherAction()
        {
            return Content("text from another action");
        }
    }
}