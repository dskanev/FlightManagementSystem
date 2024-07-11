using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Application.Handlers;
using FlightManagementSystem.Infrastructure.Data;
using FlightManagementSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Tests.Fixtures
{
    public class TestDatabaseFixture
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public TestDatabaseFixture()
        {
            var services = new ServiceCollection();

            services.AddDbContext<FlightManagementContext>(options =>
                options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=admin")
                       .EnableSensitiveDataLogging());

            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CheckInPassengerCommand).Assembly));

            ServiceProvider = services.BuildServiceProvider();

            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FlightManagementContext>();
                context.Database.Migrate();
            }
        }
    }
}
