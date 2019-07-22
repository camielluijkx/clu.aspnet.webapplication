using clu.aspnet.webapplication.mvc.Controllers;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace clu.aspnet.webapplication.mvc.Factory
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string ControllerName)
        {
            Type targetType = null;
            if (ControllerName == "Photo")
            {
                targetType = typeof(PhotoController);
            }
            else
            {
                targetType = typeof(HomeController);
            }
            return targetType == null ? null : (IController)Activator.CreateInstance(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}