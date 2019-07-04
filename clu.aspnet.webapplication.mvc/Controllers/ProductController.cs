using clu.aspnet.webapplication.mvc.Models;
using clu.aspnet.webapplication.mvc.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebStoreContext _context;

        //The parameterless version of the constructor is used by the MVC controller factory
        public ProductController()
        {
            //Instantiate an actual Entity Framework context
            _context = new RealWebStoreContext();
        }

        //This constructor is used by unit tests. They pass a test double context
        public ProductController(IWebStoreContext context)
        {
            //Use the context passed to the constructor
            _context = context;
        }

        //Add action methods here
        [HandleError(ExceptionType = typeof(NotImplementedException), View = "NotImplemented")]
        [HandleError]
        public ActionResult Index()
        {
            var model = new List<Product>();

            return View(model);
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
                    //Save pass the current Temp Data to the Error view, because it often contains
                    //diagnostic information
                    TempData = filterContext.Controller.TempData
                };
                filterContext.Result = result;
            }
        }
    }
}