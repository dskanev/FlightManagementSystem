using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Domain.Entities;
using FlightManagementSystem.Domain.Exceptions;
using FlightManagementSystem.Domain.Specifications;
using FlightManagementSystem.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Handlers
{
    public class CheckInPassengerCommandHandler : IRequestHandler<CheckInPassengerCommand>
    {
        private readonly IFlightRepository _flightRepository;

        public CheckInPassengerCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task Handle(CheckInPassengerCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository
                .GetByIdAsync(request.FlightId);

            if (flight == null)
            {
                throw new DomainException("Flight not found.");
            }

            var passenger = new Passenger(
                request.PassengerName,
                request.BaggageWeight);

            flight
                .CheckInPassenger(passenger);

            await _flightRepository
                .UpdateAsync(flight);
        }
    }
}
