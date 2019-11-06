using System;

namespace clu.aspnet.webapplication.mvc.core.Logging
{
    public class MyCustomLogger : IMyCustomLogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}