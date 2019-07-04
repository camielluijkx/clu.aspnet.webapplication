using System;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HandleError]
        public ActionResult Details()
        {
            throw new NotImplementedException();
            //throw new InvalidOperationException();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();

            // Catch invalid operation exception
            if (filterContext.Exception is InvalidOperationException)
            {
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                var result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    //Save pass the current Temp Data to the Error view, because it often contains diagnostic information
                    TempData = filterContext.Controller.TempData
                };
                filterContext.Result = result;
            }
        }
    }
}