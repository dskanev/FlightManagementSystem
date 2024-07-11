using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Models
{
    public class CheckInPassengerInputModel
    {
        public int FlightId { get; set; }

        [MinLength(3, ErrorMessage = "PassengerName must be at least 3 characters long.")]
        public string PassengerName { get; set; }

        [Range(0.00, double.MaxValue, ErrorMessage = "BaggageWeight cannot be a negative number")]
        public double BaggageWeight { get; set; }
    }
}
