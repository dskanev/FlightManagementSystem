using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Application.Models.Output;
using FlightManagementSystem.Application.Queries;
using FlightManagementSystem.Domain.Enums;
using FlightManagementSystem.Domain.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateOrderInputModel input)
        {
            await _mediator
                    .Send(new CreateOrderCommand(input));

            return Ok();
        }

        [HttpPost]
        [Route("product/create")]
        public async Task<IActionResult> CreateProduct(CreateProductInputModel input)
        {
            await _mediator
                    .Send(new CreateProductCommand(input.Price));

            return Ok();
        }

        [HttpGet]
        [Route("all")]

        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator
                .Send(new GetOrdersQuery());

            return Ok(orders);
        }

        [HttpGet]
        [Route("product/all")]

        public async Task<IActionResult> GetProducts()
        {
            var orders = await _mediator
                .Send(new GetProductsQuery());

            return Ok(orders);
        }
    }
}
