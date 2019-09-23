using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.IO;

namespace clu.aspnet.webapplication.mvc.core.Attributes
{
    public class SimpleActionFilter : ActionFilterAttribute
    {
        public SimpleActionFilter()
        {
            if (!Directory.Exists("c:\\logs"))
            {
                Directory.CreateDirectory("c:\\logs");
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("This Event Fired: OnActionExecuting");

            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            Debug.WriteLine(actionName + " started");

            using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(actionName + " started");
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("This Event Fired: OnActionExecuted");

            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            Debug.WriteLine(actionName + " finished");

            using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(actionName + " finished");
                }
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine("This Event Fired: OnResultExecuting");

            using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("OnResultExecuting");
                }
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine("This Event Fired: OnResultExecuted");

            ContentResult result = (ContentResult)filterContext.Result;
            Debug.WriteLine("Result: " + result.Content);

            using (FileStream fs = new FileStream("c:\\logs\\log.txt", FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Result: " + result.Content);
                }
            }
        }
    }
}