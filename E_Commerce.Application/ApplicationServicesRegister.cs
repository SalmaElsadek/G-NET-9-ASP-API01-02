using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.Profiles;
using E_Commerce.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Application
{
    public static class ApplicationServicesRegister
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(c => { }, typeof(ApplicationServicesRegister).Assembly);
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
