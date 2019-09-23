using clu.aspnet.webapplication.mvc.core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace clu.aspnet.webapplication.mvc.core.Attributes
{
    public class LogActionFilter : ActionFilterAttribute
    {
        //private IHostingEnvironment _environment;

        //public LogActionFilter(IHostingEnvironment environment)
        //{
        //    Console.WriteLine($"Hosting application {environment.ApplicationName}.");
        //}

        private ILogger _logger;

        public LogActionFilter(ILogger logger)
        {
            logger.LogInformation("log some information");
        }
    }
}