using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BaggageWeight { get; set; }
        public int FlightId { get; set; }

        public Passenger(string name, double baggageWeight, int flightId)
        {
            Name = name;
            BaggageWeight = baggageWeight;
            FlightId = flightId;
        }
    }
}
