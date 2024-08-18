using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Domain.Entities.Orders;
using FlightManagementSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        public CreateProductCommandHandler(IOrdersRepository ordersRepository) 
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Price);

            await _ordersRepository.CreateProduct(product);
        }
    }
}
