using clu.aspnet.webapplication.mvc.core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace clu.aspnet.webapplication.mvc.core
{
    public class Startup
    {
        private void runMiddlewareExample1(IApplicationBuilder app, IService service)
        {
            app.Use(async (context, next) =>
            {
                service.DoSomething();
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                var result = service.ReturnSomething();
                await context.Response.WriteAsync(result);
            });

            //https://localhost:44395                       : Hello World!
        }

        private void runMiddlewareExample2(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample3(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample4(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample5(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample6(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample7(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample8(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample9(IApplicationBuilder app, IService service)
        {
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not a static file.");
            });

            //https://localhost:44395                       : Not a static file.
            //https://localhost:44395/images/banner1.svg    : banner1.svg is displayed
        }

        private void runMiddlewareExample10(IApplicationBuilder app, IService service)
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

        private void runMiddlewareExample11(IApplicationBuilder app, IService service)
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

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) // setup services
        {
            services.AddSingleton<IService, Service>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices_(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IService service) // setup middleware
        {
            runMiddlewareExample1(app, service);
            //runMiddlewareExample2(app, service);
            //runMiddlewareExample3(app, service);
            //runMiddlewareExample4(app, service);
            //runMiddlewareExample5(app, service);
            //runMiddlewareExample6(app, service);
            //runMiddlewareExample7(app, service);
            //runMiddlewareExample8(app, service);
            //runMiddlewareExample9(app, service);
            //runMiddlewareExample10(app, service);
            //runMiddlewareExample11(app, service);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure_(IApplicationBuilder app, IHostingEnvironment env)
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