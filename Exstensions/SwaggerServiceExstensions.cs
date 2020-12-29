using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TessaWebAPI.Exstensions
{
    public static class SwaggerServiceExstensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            //use swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TessaWebAPI", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {

            //netcore 5 its default but maybe install swaggergen and swaggerui
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TessaWebAPI v1"));

            return app;
        }
    }
}
