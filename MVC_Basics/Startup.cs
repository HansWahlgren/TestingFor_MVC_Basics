using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVC_Basics
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a long timeout for long easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();  //add MVC so we can use it
        //    services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();  //Looks for index.html or default.html
            app.UseStaticFiles();   //default opens up the wwwroot folder to be accessed

            app.UseSession();
        //    app.UseHttpContextItemsMiddleware();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {


            // Custom/special routes before default
            endpoints.MapControllerRoute(
                name: "CustomRoute",      //Name of route rule 
                pattern: "CustomUrl",      //Url to match
                defaults: new { controller = "FeverCheck", action = "index" }     // What controller and action to call
            );
            endpoints.MapControllerRoute(
                name: "CreateRoute",      //Name of route rule 
                pattern: "CreateLinePls",      //Url to match
                defaults: new { controller = "FeverCheck", action = "Create" }     // What controller and action to call
            );
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */
            });
        }
    }
}
