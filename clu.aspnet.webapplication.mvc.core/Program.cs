using clu.aspnet.webapplication.mvc.core.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace clu.aspnet.webapplication.mvc.core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        #region Example #87

        public static IWebHostBuilder CreateWebHostBuilder87(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            IConfiguration configuration = builder.Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<Startup>();
        }

        #endregion

        #region Example #88

        public static IWebHostBuilder CreateWebHostBuilder88(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddXmlFile("config.xml");

            IConfiguration configuration = builder.Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<Startup>();
        }

        #endregion

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)

        //    .ConfigureLogging((hostingContext, logging) =>
        //    {
        //        if (hostingContext.HostingEnvironment.IsDevelopment())
        //        {
        //            logging.AddConsole(); // add logging to output window
        //        }
        //    })
        //    .UseStartup<Startup>();

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)

        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        var env = hostingContext.HostingEnvironment;
        //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    })
        //    .ConfigureLogging((hostingContext, logging) =>
        //    {
        //        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //        if (hostingContext.HostingEnvironment.IsDevelopment())
        //        {
        //            logging.AddConsole();
        //        }
        //        else
        //        {
        //            ILoggerProvider provider = new MyCustomProvider();
        //            logging.AddProvider(provider);
        //        }
        //    })
        //    .UseStartup<Startup>();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var webHost = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                })
                .UseKestrel(options =>
                {
                    options.Limits.MaxConcurrentConnections = 100;
                    options.Limits.MaxConcurrentUpgradedConnections = 50;
                    options.Limits.MaxRequestBodySize = 2 * 1024 * 1024;
                    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(3);
                })
                //.UseHttpSys(options =>
                //{
                //    options.Authentication.Schemes = Microsoft.AspNetCore.Server.HttpSys.AuthenticationSchemes.None;
                //    options.MaxConnections = 50;
                //    options.MaxRequestBodySize = 2 * 1024 * 1024;
                //    options.UrlPrefixes.Add("http://localhost:5250");
                //})
                .UseStartup<Startup>();

            return webHost;
        }
    }
}