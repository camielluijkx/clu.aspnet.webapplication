using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class ExampleController : Controller
    {
        #region Example #40

        public IActionResult Print40()
        {
            string controller = (string)RouteData.Values["Controller"];
            string action = (string)RouteData.Values["Action"];

            return Content("Controller: " + controller + ". Action: " + action);
        }

        #endregion

        #region Example #41

        public IActionResult Print41()
        {
            string id = (string)RouteData.Values["id"];

            return Content("id: " + id);
        }

        #endregion

        #region Example #42

        public IActionResult Print42(string id)
        {
            return Content("id: " + id);
        }

        #endregion

        #region Example #43

        public IActionResult Print43(int id)
        {
            return Content("id: " + id);
        }

        #endregion

        #region Example #44

        public IActionResult Print44(int? id)
        {
            return Content("id: " + id);
        }

        #endregion

        #region Example #45

        public IActionResult Print45(int id = 444)
        {
            return Content("id: " + id);
        }

        #endregion

        #region Example #46

        public IActionResult Print46(string id, string title)
        {
            return Content("id: " + id + ". title: " + title);
        }

        #endregion
    }
}