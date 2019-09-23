using clu.aspnet.webapplication.mvc.core.Attributes;
using clu.aspnet.webapplication.mvc.core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace clu.aspnet.webapplication.mvc.core
{
    public class RouteOrigin
    {
        public string Name { get; set; }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region Example #1

        public void ConfigureServices1(IServiceCollection services)
        {

        }

        public void Configure1(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            //https://localhost:44395                       : Hello World!
        }

        #endregion

        #region Example #2

        public void ConfigureServices2(IServiceCollection services)
        {
            services.AddSingleton<IMyService, MyService>();
        }

        public void Configure2(IApplicationBuilder app, IMyService myService)
        {
            app.Use(async (context, next) =>
            {
                myService.DoSomething();
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                var result = myService.ReturnSomething();
                await context.Response.WriteAsync(result);
            });

            //https://localhost:44395                       : Hello World!
        }

        #endregion

        #region Example #3

        public void ConfigureServices3(IServiceCollection services)
        {

        }

        public void Configure3(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("id"))
                {
                    await context.Response.WriteAsync($"The ID in the Query string is: {context.Request.Query["id"]}. ");
                }
                await context.Response.WriteAsync($"The path is: {context.Request.Path.Value}.");
            });

            //https://localhost:44395                       : The path is: /.
            //https://localhost:44395/test?id=3             : The ID in the Query string is: 3. The path is: / test.
        }

        #endregion

        #region Example #4

        public void ConfigureServices4(IServiceCollection services)
        {

        }

        public void Configure4(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Inside use middleware => ");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Inside run middleware");
            });

            //https://localhost:44395                       : Inside use middleware => Inside run middleware
        }

        #endregion

        #region Example #5

        public void ConfigureServices5(IServiceCollection services)
        {

        }

        public void Configure5(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Query.ContainsKey("shortcircuit"))
                {
                    await context.Response.WriteAsync("Inside use middleware");
                }
                else
                {
                    await next.Invoke();
                }
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Inside run middleware");
            });

            //https://localhost:44395                       : Inside run middleware
            //https://localhost:44395/?shortcircuit         : Inside use middleware
        }

        #endregion

        #region Example #6

        public void ConfigureServices6(IServiceCollection services)
        {

        }

        public void Configure6(IApplicationBuilder app)
        {
            app.Map("/Map", (map) =>
            {
                map.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Run middleware inside of map middleware");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Inside run middleware");
            });

            //https://localhost:44395                       : Inside run middleware
            //https://localhost:44395/Map                   : Run middleware inside of map middleware
        }

        #endregion

        #region Example #7

        public void ConfigureServices7(IServiceCollection services)
        {

        }

        public void Configure7(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First middleware => ");
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Second middleware => ");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Final middleware.");
            });

            //https://localhost:44395                       : First middleware => Second middleware => Final middleware.
        }

        #endregion

        #region Example #8

        public void ConfigureServices8(IServiceCollection services)
        {

        }

        public void Configure8(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Final middleware.");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First middleware. =>");
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Second middleware. =>");
                await next.Invoke();
            });

            //https://localhost:44395                       : Final middleware.
        }

        #endregion

        #region Example #9

        public void ConfigureServices9(IServiceCollection services)
        {

        }

        public void Configure9(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First middleware => ");
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Second middleware => ");
                if (!context.Request.Query.ContainsKey("shortcircuit"))
                {
                    await next.Invoke();
                }
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Final middleware.");
            });

            //https://localhost:44395                       : First middleware => Second middleware => Final middleware
            //https://localhost:44395?shortcircuit          : First middleware => Second middleware =>
        }

        #endregion

        #region Example #10

        public void ConfigureServices10(IServiceCollection services)
        {

        }

        public void Configure10(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not a static file.");
            });

            //https://localhost:44395                       : Not a static file.
            //https://localhost:44395/images/banner1.svg    : banner1.svg is displayed
        }

        #endregion

        #region Example #11

        public void ConfigureServices11(IServiceCollection services)
        {

        }

        public void Configure11(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFolder"))
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not a static file.");
            });

            //https://localhost:44395                       : Not a static file.
            //https://localhost:44395/images/banner1.svg    : banner1.svg is displayed
            //https://localhost:44395/Test.txt              : This is a test!
        }

        #endregion

        #region Example #12

        public void ConfigureServices12(IServiceCollection services)
        {

        }

        public void Configure12(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/wwwroot"
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFolder")),
                RequestPath = "/MyFolder"
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not a static file.");
            });

            //https://localhost:44395                           : Not a static file.
            //https://localhost:44395/images/banner1.svg        : banner1.svg is displayed
            //https://localhost:44395/MyFolder/Test.txt         : This is a test!
        }

        #endregion

        #region Example #13

        public void ConfigureServices13(IServiceCollection services)
        {
            services.AddSingleton<IFirstService, FirstService>();
            services.AddSingleton<ISecondService, SecondService>();
        }

        public void Configure13(IApplicationBuilder app, ISecondService secondService)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(secondService.GoSecond());
            });

            //https://localhost:44395                       : Going First – Going Second
        }

        #endregion

        #region Example #14

        public void ConfigureServices14(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure14(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : Hello from controller
            //https://localhost:44395/Fake                  : Page not found
            //https://localhost:44395/Home                  : Hello from controller
            //https://localhost:44395/Home/Index            : Hello from controller
            //https://localhost:44395/Home/Unknown          : Page not found
        }

        #endregion

        #region Example #15

        public void ConfigureServices15(IServiceCollection services)
        {
            services.AddSingleton<IMyService, MyService>();

            services.AddMvc();
        }

        public void Configure15(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : Hello from service
            //https://localhost:44395/Fake                  : Page not found
            //https://localhost:44395/Home                  : Hello from service
            //https://localhost:44395/Home/Index            : Hello from service
            //https://localhost:44395/Home/Unknown          : Page not found
        }

        #endregion

        #region Example #16

        public void ConfigureServices16(IServiceCollection services)
        {
            // all requests: The number from service in controller: x, the number from wrapper service: x
            services.AddSingleton<IRandomService, RandomService>();
            services.AddSingleton<IRandomWrapper, RandomWrapper>();

            services.AddMvc();
        }

        public void Configure16(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });
        }

        #endregion

        #region Example #17

        public void ConfigureServices17(IServiceCollection services)
        {
            // per request: The number from service in controller: x, the number from wrapper service: x
            services.AddScoped<IRandomService, RandomService>();
            services.AddScoped<IRandomWrapper, RandomWrapper>();

            services.AddMvc();
        }

        public void Configure17(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });
        }

        #endregion

        #region Example #18

        public void ConfigureServices18(IServiceCollection services)
        {
            // per request: The number from service in controller: x, the number from wrapper service: y
            services.AddTransient<IRandomService, RandomService>();
            services.AddTransient<IRandomWrapper, RandomWrapper>();

            services.AddMvc();
        }

        public void Configure18(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });
        }

        #endregion

        #region Example #19

        public void ConfigureServices19(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure19(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : My Value
        }

        #endregion

        #region Example #20

        public void ConfigureServices20(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure20(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : some text
        }

        #endregion

        #region Example #21

        public void ConfigureServices21(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure21(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : text from another action
        }

        #endregion

        #region Example #22

        public void ConfigureServices22(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure22(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : text from another controller
        }

        #endregion

        #region Example #23

        public void ConfigureServices23(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure23(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : 404
        }

        #endregion

        #region Example #24

        public void ConfigureServices24(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure24(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //https://localhost:44395                       :
            //https://localhost:44395/Fake                  : 404 
            //https://localhost:44395/Home                  :
            //https://localhost:44395/Home/Index            :
            //https://localhost:44395/Home/Unknown          : 404
            //https://localhost:44395/Home/Index/8          : 8
        }

        #endregion

        #region Example #25

        public void ConfigureServices25(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure25(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //https://localhost:44395                       :
            //https://localhost:44395/Fake                  : 404
            //https://localhost:44395/Home                  :
            //https://localhost:44395/Home/Index            :
            //https://localhost:44395/Home/Unknown          : 404
            //https://localhost:44395/Home/Index/8          : 8
        }

        #endregion

        #region Example #26

        public void ConfigureServices26(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure26(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //https://localhost:44395/Home/Index/8          : 
            //https://localhost:44395/Home/Index/?id=8      : 8
        }

        #endregion

        #region Example #27

        public void ConfigureServices27(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure27(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //https://localhost:44395                       : Message is: some text
            //                                                m/dd/yyyy h:mm:ss tt
        }

        #endregion

        #region Example #28

        public void ConfigureServices28(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure28(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //https://localhost:44395                       : Message is: some text
            //                                                m/dd/yyyy h:mm:ss tt
        }

        #endregion

        #region Example #29

        public void ConfigureServices29(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure29(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(); // no routes are configured

            //https://localhost:44395                       : 404
            //https://localhost:44395/Some/Display          : 404
        }

        #endregion

        #region Example #30

        public void ConfigureServices30(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure30(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "myRoute",
                    template: "{action}/{controller}");
            });

            //https://localhost:44395                       : 404
            //https://localhost:44395/Some/Display          : 404
            //https://localhost:44395/Display/Some          : Reached the action
        }

        #endregion

        #region Example #31

        public void ConfigureServices31(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure31(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });

            //https://localhost:44395/Some/Display          : Reached the action
            //https://localhost:44395/Some/Display/1        : 404
            //https://localhost:44395/Some/Display?id=1     : Reached the action
        }

        #endregion

        #region Example #32

        public void ConfigureServices32(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure32(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{param}");
            });

            //https://localhost:44395/Some/Display          : 404
            //https://localhost:44395/Some/Display/1        : Reached the action
            //https://localhost:44395/Some/Display?id=1     : 404
            //https://localhost:44395/Some/Display/1?id=1   : Reached the action
            //https://localhost:44395/Some/ShowParam/hello   : hello
        }

        #endregion

        #region Example #33

        public void ConfigureServices33(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure33(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{param}",
                    defaults: new { controller = "Some", action = "ShowParam", param = "val" });
            });

            //https://localhost:44395                        : val
            //https://localhost:44395/Some                   : val
            //https://localhost:44395/Some/ShowParam         : val
            //https://localhost:44395/Some/ShowParam/hello   : hello
        }

        #endregion

        #region Example #34

        public void ConfigureServices34(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure34(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Some}/{action=ShowParam}/{param=val}");
            });

            //https://localhost:44395                        : val
            //https://localhost:44395/Some                   : val
            //https://localhost:44395/Some/ShowParam         : val
            //https://localhost:44395/Some/ShowParam/hello   : hello
        }

        #endregion

        #region Example #35

        public void ConfigureServices35(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure35(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{param}",
                    defaults: new { controller = "Some", action = "ShowParam" },
                    constraints: new { param = "[0-9]+" });
            });

            //https://localhost:44395                        : 404
            //https://localhost:44395/Some                   : 404
            //https://localhost:44395/Some/ShowParam         : 404
            //https://localhost:44395/Some/ShowParam/hello   : 404
            //https://localhost:44395/Some/ShowParam/12345   : 12345
        }

        #endregion

        #region Example #36

        public void ConfigureServices36(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure36(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "showParam",
                    template: "{controller=Some}/{action=ShowParam}/{param}");

                routes.MapRoute(
                    name: "showNumber",
                    template: "{controller=Some}/{action=ShowNumber}/{param:int}");
            });

            //https://localhost:44395/Some/ShowParam/hello   : hello
            //https://localhost:44395/Some/ShowParam/12345   : 12345
            //https://localhost:44395/Some/ShowNumber/hello  : 0
            //https://localhost:44395/Some/ShowNumber/12345  : 12345
        }

        #endregion

        #region Example #37

        public void ConfigureServices37(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure37(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "showParam",
                    template: "{controller=Some}/{action=FancyParam}/{param}",
                    defaults: null,
                    constraints: null,
                    dataTokens: new { routeOrigin = new RouteOrigin { Name = "fancy param route" } });

                routes.MapRoute(
                    name: "showNumber",
                    template: "{controller=Some}/{action=FancyNumber}/{param:int}",
                    defaults: null,
                    constraints: null,
                    dataTokens: new { routeOrigin = new RouteOrigin { Name = "fancy number route" } });
            });

            //https://localhost:44395/Some/FancyParam/hello  : This is some controller.
            //                                                 The route data is 'fancy param route'
            //https://localhost:44395/Some/FancyNumber/12345 : This is some controller.
            //                                                 The route data is 'fancy number route'
        }

        #endregion

        #region Example #38

        public void ConfigureServices38(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure38(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "firstRoute",
                    template: "{controller}/{action}/{param}",
                    defaults: new { controller = "Some", action = "ShowNumber" },
                    constraints: new { param = "[0-9]+" });

                routes.MapRoute(
                    name: "secondRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //https://localhost:44395/Some/ShowNumber/hello  : 0
            //https://localhost:44395/Some/ShowNumber/hello  : 12345
            //https://localhost:44395                        : Home > Index
        }

        #endregion

        #region Example #39

        public void ConfigureServices39(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure39(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "secondRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "firstRoute",
                    template: "{controller}/{action}/{param}",
                    defaults: new { controller = "Some", action = "ShowNumber" },
                    constraints: new { param = "[0-9]+" });
            });

            //https://localhost:44395/Some/ShowNumber/hello  : 0
            //https://localhost:44395/Some/ShowNumber/12345  : 0
            //https://localhost:44395                        : Home > Index
        }

        #endregion

        #region Example #40

        public void ConfigureServices40(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure40(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "someRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Example", action = "Print" });
            });

            //https://localhost:44395/Example/Print         : Controller: Example. Action: Print 
        }

        #endregion

        #region Example #41

        public void ConfigureServices41(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure41(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "someRoute",
                    template: "{controller}/{action}/{id?}", // id is optional (e.g. null also matches)
                    defaults: new { controller = "Example", action = "Print" });
            });

            //https://localhost:44395/Example/Print         : id:
            //https://localhost:44395/Example/Print/8       : id: 8
        }

        #endregion

        #region Example #42

        public void ConfigureServices42(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure42(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "someRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Example", action = "Print" });
            });

            //https://localhost:44395/Example/Print         : id:
            //https://localhost:44395/Example/Print/8       : id:8
        }

        #endregion

        #region Example #43

        public void ConfigureServices43(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure43(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "someRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Example", action = "Print" });
            });

            //https://localhost:44395/Example/Print         : id: 0
            //https://localhost:44395/Example/Print/8       : id: 8
        }

        #endregion

        #region Example #44

        public void ConfigureServices44(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure44(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "someRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Example", action = "Print" });
            });

            //https://localhost:44395/Example/Print         : id: 
            //https://localhost:44395/Example/Print/8       : id: 8
        }

        #endregion

        #region Example #45

        public void ConfigureServices45(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure45(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "someRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Example", action = "Print" });
            });

            //https://localhost:44395/Example/Print         : id: 444
            //https://localhost:44395/Example/Print/8       : id: 8
        }

        #endregion

        #region Example #46

        public void ConfigureServices46(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure46(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "someRoute",
                    template: "{controller}/{action}/{id}/{title?}",
                    defaults: new { controller = "Example", action = "Print" });
            });

            //https://localhost:44395/Example/Print         : 404
            //https://localhost:44395/Example/Print/8       : id: 8. title: 
            //https://localhost:44395/Example/Print/8/ABC   : id: 8. title: ABC
            //https://localhost:44395/Example/Print/ABC/8   : id: ABC. title: 8
        }

        #endregion

        #region Example #47

        public void ConfigureServices47(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure47(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            //https://localhost:44395                       : 404
            //https://localhost:44395/Some                  : Some method
        }

        #endregion

        #region Example #48

        public void ConfigureServices48(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure48(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            //https://localhost:44395                       : 404
            //https://localhost:44395/My                    : 404
            //https://localhost:44395/hello                 : hello
        }

        #endregion

        #region Example #49

        public void ConfigureServices49(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure49(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            //https://localhost:44395                       : 404
            //https://localhost:44395/My                    : 404
            //https://localhost:44395/My/hello              : hello
            //https://localhost:44395/My/hello/8            : param1: hello, param2: 8
            //https://localhost:44395/My/hello/Joe          : 404
        }

        #endregion

        #region Example #50

        public void ConfigureServices50(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure50(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            //https://localhost:44395                       : 404
            //https://localhost:44395/My                    : 404
            //https://localhost:44395/My/hello              : hello
            //https://localhost:44395/My/hello/8            : param1: hello, param2: 8
            //https://localhost:44395/My/hello/Joe          : param1: hello, param2: Joe
        }

        #endregion

        #region Example #51

        public void ConfigureServices51(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure51(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            //https://localhost:44395/My/Method1            : Method1
            //https://localhost:44395/My/Method2            : Method2
        }

        #endregion

        #region Example #52

        public void ConfigureServices52(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure52(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });

            //https://localhost:44395/SomeRoute             : Method1
            //https://localhost:44395/Extra/SomeRoute       : 404
            //https://localhost:44395/Extra/Method1         : 404
            //https://localhost:44395/Extra/Method2         : Method2
        }

        #endregion

        #region Example #53

        public void ConfigureServices53(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure53(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            //https://localhost:44395/Cities/1              : City 1
        }

        #endregion

        #region Example #54

        public void ConfigureServices54(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure54(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            //https://localhost:44395/Cities                : City 1, City 2, City 3
            //https://localhost:44395/Cities/1              : City 1
        }

        #endregion

        #region Example #55

        public void ConfigureServices55(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure55(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395/Some                  : OnActionExecuting > OnActionExecuted > OnResultExecuting > OnResultExecuted
        }

        #endregion

        #region Example #56

        public void ConfigureServices56(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //options.Filters.Add(new LogActionFilter(...)); // an instant
                options.Filters.Add(typeof(LogActionFilter)); // by type
            });

            services.AddSingleton<ILogger, Logger>();

            //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.2
        }

        public void Configure56(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395/Cities                : ActionFilterAttribute
        }

        #endregion

        #region Example #61

        public void ConfigureServices61(IServiceCollection services)
        {
            // all requests: The number from service in controller: x, the number from wrapper service: x
            services.AddSingleton<IFormatNumber, FormatNumber>();

            services.AddMvc();
        }

        public void Configure61(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395/Product               : Index -> View
        }

        #endregion

        #region Example #62

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395/images/test.jpg       : test.jpg is displayed
            //https://localhost:44395/Photo/Choose          : Index -> View
            //https://localhost:44395/Photo/GetImage/1      : test.jpg
        }

        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        public void _ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void _Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}