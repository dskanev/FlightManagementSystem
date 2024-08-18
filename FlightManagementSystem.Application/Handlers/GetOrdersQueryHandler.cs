using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Application.Models.Output;
using FlightManagementSystem.Application.Queries;
using FlightManagementSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderOutputModel>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetOrdersQueryHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IEnumerable<OrderOutputModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _ordersRepository.GetAllOrders();

            return orders;
        }
    }
}
