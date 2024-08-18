using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Domain.Entities;
using FlightManagementSystem.Domain.Entities.Orders;
using FlightManagementSystem.Domain.Exceptions;
using FlightManagementSystem.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlightManagementSystem.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;

        public CreateOrderCommandHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Customer customer = null;

                if (request.ProductIds == null || !request.ProductIds.Any())
                {
                    throw new Exception("Order must contain at least one item.");
                }

                if (request.CustomerId != null)
                {
                    customer = await _ordersRepository.GetCustomer(request.CustomerId.Value);

                    if (customer == null)
                    {
                        throw new Exception("Customer not found");
                    }
                }
                else
                {
                    customer = new Customer(
                        request.CustomerName,
                        request.CustomerPhone,
                        request.CustomerEmail,
                        new Address(request.City, request.Street, request.PostalCode));
                }

                var products = await _ordersRepository.GetProducts(request.ProductIds);

                var order = Order.Create(request.CustomerId, customer, products);

                await _ordersRepository.CreateOrder(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                await this.Handle(request, cancellationToken);
            }
        }
    }
}
