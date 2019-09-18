using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class SomeController : Controller
    {
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