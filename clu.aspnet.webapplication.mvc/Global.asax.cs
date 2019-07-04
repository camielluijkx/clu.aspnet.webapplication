using clu.aspnet.webapplication.mvc.Factory;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace clu.aspnet.webapplication.mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Register custom controller factory implementation.
            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
        }
    }
}