using FlightManagementSystem.Application.Models;
using FlightManagementSystem.Domain.Enums;
using FlightManagementSystem.Domain.Models.Input;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public IList<Guid> ProductIds { get; set; } = new List<Guid>();
        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

        public CreateOrderCommand(CreateOrderInputModel input)
        {
            City = input.City;
            Street = input.Street;
            PostalCode = input.PostalCode;
            ProductIds = input.ProductIds;
            CustomerId = input.CustomerId;
            CustomerName = input.CustomerName;
            CustomerPhone = input.CustomerPhone;
            CustomerEmail = input.CustomerEmail;
        }
    }
}
