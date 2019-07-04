using System;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult Error(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            ViewBag.StatusCode = $"Error {statusCode}";
            return View();
        }
    }
}