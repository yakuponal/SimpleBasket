using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBasket.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBasket.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleBasketDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SimpleBasketDb")));
            services.AddScoped<ISimpleBasketDbContext, SimpleBasketDbContext>();

            return services;
        }
    }
}
