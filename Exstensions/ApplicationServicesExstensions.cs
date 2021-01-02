using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Errors;
using TessaWebAPI.Implementation;
using TessaWebAPI.Interfaces;

namespace TessaWebAPI.Exstensions
{
    public static class ApplicationServicesExstensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //use product repository pattern
            services.AddScoped<IProductRepository, ProductRepository>();
            //use generic repository
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            //add basket repository
            services.AddScoped<IBasketRepository, BasketRepository>();

            //configure validation api behavior
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
