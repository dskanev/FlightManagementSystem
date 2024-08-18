using FlightManagementSystem.Application.Models.Output;
using FlightManagementSystem.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderOutputModel>>
    {
        public GetOrdersQuery()
        {
        }
    }
}
