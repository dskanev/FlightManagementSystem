using FlightManagementSystem.Application.Queries;
using FlightManagementSystem.Domain.Models.Output;
using FlightManagementSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductOutputModel>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetProductsQueryHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IEnumerable<ProductOutputModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _ordersRepository.GetAllProducts();
            return products;
        }
    }
}
