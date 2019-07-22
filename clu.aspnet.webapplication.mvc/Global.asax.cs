using clu.aspnet.webapplication.mvc.App_Start;
using clu.aspnet.webapplication.mvc.Controllers;
using clu.aspnet.webapplication.mvc.Factory;
using clu.aspnet.webapplication.mvc.Repository;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace clu.aspnet.webapplication.mvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Register custom controller factory implementation.
            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());

            Database.SetInitializer<PhotoSharingContext>(new PhotoSharingInitializer());
        }

        /// <summary>
        /// Handles an unhandled exception when it is being thrown by the application (for example when a route is not resolved).
        /// </summary>
        public void Application_Error(Object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Server.ClearError();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "ErrorPage");
            routeData.Values.Add("action", "Error");
            routeData.Values.Add("exception", exception);

            if (exception.GetType() == typeof(HttpException))
            {
                routeData.Values.Add("statusCode", ((HttpException)exception).GetHttpCode());
            }
            else
            {
                routeData.Values.Add("statusCode", 500);
            }

            Response.TrySkipIisCustomErrors = true;
            IController controller = new ErrorPageController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            Response.End();
        }
    }
}