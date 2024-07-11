using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Application.Handlers;
using FlightManagementSystem.Application.Models;
using FlightManagementSystem.Domain.Entities;
using FlightManagementSystem.Domain.Exceptions;
using FlightManagementSystem.Infrastructure.Data;
using FlightManagementSystem.Infrastructure.Database;
using FlightManagementSystem.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Tests.IntegrationTests
{
    [Collection("TestDatabase")]
    public class CheckInIntegrationTests
    {
        private readonly IServiceProvider _serviceProvider;

        public CheckInIntegrationTests(TestDatabaseFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task Concurrent_CheckIns_WhenOnlyOneSeatIsAvailable_Should_Throw_DomainException()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FlightManagementContext>();

                var flight = new Flight(99999, "ABC", 1, 20);
                
                await context.AddAsync(flight);
                await context.SaveChangesAsync();

                var task1 = Task.Run(async () =>
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var flightRepository = scope.ServiceProvider.GetRequiredService<IFlightRepository>();
                        var commandHandler = new CheckInPassengerCommandHandler(flightRepository);
                        var command = new CheckInPassengerCommand(new CheckInPassengerInputModel { FlightId = flight.Id, PassengerName = "Passenger 1", BaggageWeight = 20 });
                        await commandHandler.Handle(command, CancellationToken.None);
                    }
                });

                var task2 = Task.Run(async () =>
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var flightRepository = scope.ServiceProvider.GetRequiredService<IFlightRepository>();
                        var commandHandler = new CheckInPassengerCommandHandler(flightRepository);
                        var command = new CheckInPassengerCommand(new CheckInPassengerInputModel { FlightId = flight.Id, PassengerName = "Passenger 2", BaggageWeight = 20 });
                        await commandHandler.Handle(command, CancellationToken.None);
                    }
                });

                context.Remove(flight);
                await context.SaveChangesAsync();

                await Assert.ThrowsAsync<DomainException>(() => Task.WhenAll(task1, task2));                
            }
        }
    }
}
