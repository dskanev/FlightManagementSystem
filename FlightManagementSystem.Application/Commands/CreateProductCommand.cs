using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Commands
{
    public class CreateProductCommand : IRequest
    {
        public double Price { get; set; }

        public CreateProductCommand(double price)
        {
            Price = price;
        }
    }
}
