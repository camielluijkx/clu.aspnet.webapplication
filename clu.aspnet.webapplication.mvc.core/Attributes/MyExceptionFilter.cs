using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace clu.aspnet.webapplication.mvc.core.Attributes
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = new ViewResult { ViewName = "InvalidModel" };

                context.Result = result;
                context.ExceptionHandled = true;
            }
        }
    }
}