using clu.aspnet.webapplication.mvc.core.Logging;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;

namespace clu.aspnet.webapplication.mvc.core.Attributes
{
    public class LogActionFilter : ActionFilterAttribute
    {
        //private IHostingEnvironment _environment;

        //public LogActionFilter(IHostingEnvironment environment)
        //{
        //    Console.WriteLine($"Hosting application {environment.ApplicationName}.");
        //}

        private IMyCustomLogger _logger;

        public LogActionFilter(IMyCustomLogger logger)
        {
            logger.LogInformation("log some information");
        }
    }
}