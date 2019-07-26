using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(clu.aspnet.webapplication.mvc.net.Startup))]

namespace clu.aspnet.webapplication.mvc.net
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}