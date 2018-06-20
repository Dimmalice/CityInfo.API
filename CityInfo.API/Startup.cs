using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.API
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage(); //middleware
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });






            //app.Run((context) =>
            //{
            //    throw new Exception("example");
            //});


            //app.Run(async (context) =>
            //{
            //    if (context.Request.Path.ToString().Contains("mitsos"))
            //    {
            //        await context.Response.WriteAsync("Hello mitsos!");
            //    }
            //    else { 
            //        await context.Response.WriteAsync("Hello World!");
            //    }
            //});
        }

    }
}
