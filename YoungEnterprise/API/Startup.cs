﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoungEnterprise_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace YoungEnterprise_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddMvc();

            //DESKTOP-6D9EMB1 mikkel
            //DESKTOP-ACNIRC0 louise
            var connection = @"Server=DESKTOP-ACNIRC0;Database=DB_YoungEnterprise;Trusted_Connection=True;";
            services.AddDbContext<DB_YoungEnterpriseContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
           
            app.UseExceptionHandler("/ErrorPage.html");
  
            app.UseStaticFiles();

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=APIStartPage}/{id?}");
            });
        }
    }
}
