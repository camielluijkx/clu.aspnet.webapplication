using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class SomeController : Controller
    {
        #region Example #72

        [Route("Some/Index72")]
        public IActionResult Index72()
        {
            SomeModel model = new SomeModel { Text = "some text" };

            return View(model);

            //https://localhost:44395/Some/Index             : some text
        }

        #endregion

        #region Example #73

        [Route("Some/Index73")]
        public IActionResult Index73()
        {
            SomeModel item1 = new SomeModel { Text = "first item" };
            SomeModel item2 = new SomeModel { Text = "second item" };

            List<SomeModel> items = new List<SomeModel>() { item1, item2 };

            return View(items);

            //https://localhost:44395/Some/Index             : first item
            //                                                 second item
        }

        #endregion

        #region Example #74

        [Route("Some/Index")]
        public IActionResult Index()
        {
            SomeModel model = new SomeModel { Text = "display text" };

            return View("Display", model);

            //https://localhost:44395/Some/Index             : display text
        }

        #endregion

        public IActionResult Display()
        {
            return Content("Reached the action");
        }

        public IActionResult ShowParam(string param)
        {
            return Content(param);
        }

        public IActionResult FancyParam(string param)
        {
            var origin = (RouteOrigin)RouteData.DataTokens["routeOrigin"];

            return Content($"This is some controller.\nThe route data is '{origin.Name}'");
        }

        public IActionResult ShowNumber(int param)
        {
            return Content($"{param}");
        }

        public IActionResult FancyNumber()
        {
            var origin = (RouteOrigin)RouteData.DataTokens["routeOrigin"];

            return Content($"This is some controller.\nThe route data is '{origin.Name}'");
        }
    }
}