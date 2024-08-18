using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Domain.Exceptions;
using FlightManagementSystem.Domain.Models.Input;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : Controller
    {
        private readonly IMediator _mediator;

        public CheckInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CheckInPassenger([FromBody] CheckInPassengerInputModel input)
        {
            try
            {
                await _mediator
                    .Send(new CheckInPassengerCommand(input));

                return Ok();
            }
            catch (DomainException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
