using FlightManagementSystem.Infrastructure.Data;
using FlightManagementSystem.Infrastructure.Database;
using FlightManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Infrastructure.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            services
                .AddRepositories()
                .AddDatabase(configurationManager);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfigurationManager configurationManager)
        {
            services.AddDbContext<FlightManagementContext>(options =>
                options.UseNpgsql(configurationManager.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
