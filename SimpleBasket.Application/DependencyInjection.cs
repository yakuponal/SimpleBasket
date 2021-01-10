using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleBasket.Application.Common.Interfaces;
using SimpleBasket.Application.Services;
using System.Reflection;

namespace SimpleBasket.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
