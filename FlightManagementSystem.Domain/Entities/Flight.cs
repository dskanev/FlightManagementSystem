using FlightManagementSystem.Domain.Exceptions;
using FlightManagementSystem.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities
{
    public class Flight
    {
        public int Id { get; private set; }
        public string FlightNumber { get; private set; }
        public int SeatCapacity { get; private set; }
        public List<Passenger> Passengers { get; private set; } = new List<Passenger>();
        public int MaxBaggageWeight { get; private set; }

        [Timestamp]
        public uint Version { get; set; }

        public Flight(int id, string flightNumber, int seatCapacity, int maxBaggageWeight)
        {
            Id = id;
            FlightNumber = flightNumber;
            SeatCapacity = seatCapacity;
            MaxBaggageWeight = maxBaggageWeight;
        }

        public void CheckInPassenger(Passenger passenger)
        {
            var flightSpecifications = new CompositeSpecification<Flight>();
            flightSpecifications.Add(new FlightCapacitySpecification());

            var passengerSpecifications = new CompositeSpecification<Passenger>();
            passengerSpecifications.Add(new BaggageWeightSpecification(MaxBaggageWeight));

            if (!flightSpecifications.IsSatisfiedBy(this))
                throw new DomainException(flightSpecifications.ErrorMessage);

            if (!passengerSpecifications.IsSatisfiedBy(passenger))
                throw new DomainException(passengerSpecifications.ErrorMessage);

            Passengers.Add(passenger);
        }
    }
}
