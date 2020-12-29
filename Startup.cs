using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Data;
using TessaWebAPI.Errors;
using TessaWebAPI.Exstensions;
using TessaWebAPI.Helpers;
using TessaWebAPI.Implementation;
using TessaWebAPI.Interfaces;
using TessaWebAPI.Middleware;

namespace TessaWebAPI
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

            services.AddControllers();
            
            //add sql sever connection link 
            services.AddDbContext<StoreContext>(db => db.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           
            //add automapper
            services.AddAutoMapper(typeof(MappingProfiles));

            //use my made exstensions for not overloading startup class
            services.AddApplicationServices();

            //use my swagger exstension
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
             if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseMiddleware<ExceptionMiddleware>(); //use custom exception middleware

                //use my exstension for adding swagger
                app.UseSwaggerDocumentation();
            }
             

            //redirects to ErrorController and passes error code
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            //use wwwroot for static files
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
