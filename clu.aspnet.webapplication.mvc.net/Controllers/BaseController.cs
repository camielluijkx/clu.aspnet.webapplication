using System;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.net.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Handles an unhandled exception when it is being thrown by a controller using <see cref="BaseController"/> as it's base.
        /// </summary>
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