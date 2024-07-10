using FlightManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Specifications
{
    public class BaggageWeightSpecification : ISpecification<Passenger>
    {
        private readonly int _maxBaggageWeight;
        public string ErrorMessage => "Baggage weight exceeds the limit.";


        public BaggageWeightSpecification(int maxBaggageWeight)
        {
            _maxBaggageWeight = maxBaggageWeight;
        }

        public bool IsSatisfiedBy(Passenger passenger)
        {
            return passenger.BaggageWeight <= _maxBaggageWeight;
        }
    }
}
