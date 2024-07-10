using FlightManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Specifications
{
    public class FlightCapacitySpecification : ISpecification<Flight>
    {
        public string ErrorMessage => "Flight is full.";

        public bool IsSatisfiedBy(Flight flight)
        {
            return flight.Passengers.Count < flight.SeatCapacity;
        }
    }
}
