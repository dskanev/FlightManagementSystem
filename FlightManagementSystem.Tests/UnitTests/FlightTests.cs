using FlightManagementSystem.Domain.Entities;
using FlightManagementSystem.Domain.Exceptions;
using FlightManagementSystem.Domain.Specifications;
using FluentAssertions;
using Moq;

namespace FlightManagementSystem.Tests.UnitTests
{
    public class FlightTests
    {
        [Fact]
        public void CheckInPassenger_Should_Add_Passenger_When_Specifications_Are_Satisfied()
        {
            // Arrange
            var flight = new Flight(1, "AB123", 100, 200);
            var passenger = new Passenger("Passenger 1", 25, 1);

            // Act
            flight.CheckInPassenger(passenger);

            // Assert
            flight.Passengers.Should().Contain(passenger);
        }

        [Fact]
        public void CheckInPassenger_Should_Throw_Exception_When_FlightCapacitySpecification_Is_Not_Satisfied()
        {
            // Arrange
            var flight = new Flight(1, "AB123", 0, 200);
            var passenger = new Passenger("Passenger 1", 25, 1);

            // Act
            Action act = () => flight.CheckInPassenger(passenger);

            // Assert
            act.Should().Throw<DomainException>().WithMessage("Flight is full.");
        }

        [Fact]
        public void CheckInPassenger_Should_Throw_Exception_When_BaggageWeightSpecification_Is_Not_Satisfied()
        {
            // Arrange
            var flight = new Flight(1, "AB123", 150, 20);
            var passenger = new Passenger("Passenger 1", 25, 1);

            // Act
            Action act = () => flight.CheckInPassenger(passenger);

            // Assert
            act.Should().Throw<DomainException>().WithMessage("Baggage weight exceeds the limit.");
        }
    }
}
