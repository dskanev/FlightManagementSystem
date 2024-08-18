using FlightManagementSystem.Domain.Models.Output;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductOutputModel>>
    {
        public GetProductsQuery() { }
    }
}
