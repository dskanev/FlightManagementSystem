using FlightManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Models.Output
{
    public class OrderOutputModel
    {
        public Guid Id { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Fullfilled { get; set; }
        public double Total { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int Items { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public OrderStatus Status { get; set; }
    }
}
