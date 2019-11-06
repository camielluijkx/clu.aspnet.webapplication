using Microsoft.Extensions.Logging;

namespace clu.aspnet.webapplication.mvc.core.Logging
{
    public class MyCustomProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}