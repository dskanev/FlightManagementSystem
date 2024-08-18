using FlightManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Models.Input
{
    public class CreateOrderInputModel
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public IList<Guid> ProductIds { get; set; }
        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}
