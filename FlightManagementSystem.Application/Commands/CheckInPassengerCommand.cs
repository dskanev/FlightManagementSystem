using FlightManagementSystem.Domain.Models.Input;
using MediatR;

namespace FlightManagementSystem.Application.Commands
{
    public class CheckInPassengerCommand : IRequest
    {
        public int FlightId { get; private set; }
        public string PassengerName { get; private set; }
        public double BaggageWeight { get; private set; }

        public CheckInPassengerCommand(CheckInPassengerInputModel input)
        {
            FlightId = input.FlightId;
            PassengerName = input.PassengerName;
            BaggageWeight = input.BaggageWeight;
        }
    }
}
