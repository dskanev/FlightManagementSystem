using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Models
{
    public class CheckInPassengerInputModel
    {
        public Guid FlightId { get; set; }
        public string PassengerName { get; set; }
        public double BaggageWeight { get; set; }
    }
}
