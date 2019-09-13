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
        private void runMiddlewareExample1(IApplicationBuilder app)
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

        private void runMiddlewareExample2(IApplicationBuilder app)
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

        private void runMiddlewareExample3(IApplicationBuilder app)
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

        private void runMiddlewareExample4(IApplicationBuilder app)
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

        private void runMiddlewareExample5(IApplicationBuilder app)
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

        private void runMiddlewareExample6(IApplicationBuilder app)
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

        private void runMiddlewareExample7(IApplicationBuilder app)
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

        private void runMiddlewareExample8(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not a static file.");
            });

            //https://localhost:44395                       : Not a static file.
            //https://localhost:44395/images/banner1.svg    : banner1.svg is displayed
        }

        private void runMiddlewareExample9(IApplicationBuilder app)
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

        private void runMiddlewareExample10(IApplicationBuilder app)
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

        private void runServicesExample1(IApplicationBuilder app, IMyService myService)
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

        private void runServicesExample2(IApplicationBuilder app, ISecondService secondService)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(secondService.GoSecond());
            });

            //https://localhost:44395                       : Going First – Going Second
        }

        private void runServicesExample3(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });

            //https://localhost:44395                       : response from home controller
            //https://localhost:44395/Home                  : response from home controller
            //https://localhost:44395/Home/Index            : response from home controller
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMyService, MyService>();

            services.AddSingleton<IFirstService, FirstService>();
            services.AddSingleton<ISecondService, SecondService>();

            // all requests: The number from service in controller: x, the number from wrapper service: x
            //services.AddSingleton<IRandomService, RandomService>();
            //services.AddSingleton<IRandomWrapper, RandomWrapper>();

            // per request: The number from service in controller: x, the number from wrapper service: x
            //services.AddScoped<IRandomService, RandomService>();
            //services.AddScoped<IRandomWrapper, RandomWrapper>();

            // per request: The number from service in controller: x, the number from wrapper service: y
            services.AddTransient<IRandomService, RandomService>();
            services.AddTransient<IRandomWrapper, RandomWrapper>();

            services.AddMvc();
        }

        public void Configure_(IApplicationBuilder app)
        {
            runMiddlewareExample1(app);
            //runMiddlewareExample2(app);
            //runMiddlewareExample3(app);
            //runMiddlewareExample4(app);
            //runMiddlewareExample5(app);
            //runMiddlewareExample6(app);
            //runMiddlewareExample7(app);
            //runMiddlewareExample8(app);
            //runMiddlewareExample9(app);
            //runMiddlewareExample10(app);
        }

        public void Configure_(IApplicationBuilder app, IMyService myService)
        {
            runServicesExample1(app, myService);
        }

        public void Configure_(IApplicationBuilder app, ISecondService secondService)
        {
            runServicesExample2(app, secondService);
        }

        public void Configure(IApplicationBuilder app)
        {
            runServicesExample3(app);
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