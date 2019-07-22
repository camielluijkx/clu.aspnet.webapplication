using System;
using System.Web;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class ErrorPageController : BaseController
    {
        /// <summary>
        /// Returns an error model whenever an application exception was handled.
        /// </summary>
        public ActionResult Error(int statusCode, Exception exception)
        {
            if (exception.GetType() == typeof(HttpException))
            {
                exception = new HttpException("The page you requested does not exist!");
            }

            var model = new HandleErrorInfo(exception, "ErrorPage", "Error");

            Response.StatusCode = statusCode;
            ViewBag.StatusCode = $"Error {statusCode}";

            return View(model);
        }
    }
}