using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities
{
    public class Passenger
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double BaggageWeight { get; private set; }

        public Passenger(string name, double baggageWeight)
        {
            Id = Guid.NewGuid();
            Name = name;
            BaggageWeight = baggageWeight;
        }
    }
}
