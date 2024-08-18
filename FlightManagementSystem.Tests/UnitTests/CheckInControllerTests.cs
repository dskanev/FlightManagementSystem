using FlightManagementSystem.Application.Commands;
using FlightManagementSystem.Application.Models;
using FlightManagementSystem.Controllers;
using FlightManagementSystem.Domain.Exceptions;
using FlightManagementSystem.Domain.Models;
using FlightManagementSystem.Domain.Models.Input;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Tests.UnitTests
{
    public class CheckInControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CheckInController _controller;

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }

        public CheckInControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CheckInController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CheckInPassenger_Should_Return_Ok_When_Command_Is_Successful()
        {
            // Arrange
            var inputModel = new CheckInPassengerInputModel();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CheckInPassengerCommand>(), default))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CheckInPassenger(inputModel);

            // Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task CheckInPassenger_Should_Return_BadRequest_When_DomainException_Is_Thrown()
        {
            // Arrange
            var inputModel = new CheckInPassengerInputModel();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CheckInPassengerCommand>(), default))
                .ThrowsAsync(new DomainException("Flight is full"));

            // Act
            var result = await _controller.CheckInPassenger(inputModel);

            // Assert
            var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
            badRequestResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task CheckInPassenger_Should_Return_InternalServerError_When_Unhandled_Exception_Is_Thrown()
        {
            // Arrange
            var inputModel = new CheckInPassengerInputModel();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CheckInPassengerCommand>(), default))
                .ThrowsAsync(new Exception("Something went wrong"));

            // Act
            var result = await _controller.CheckInPassenger(inputModel);

            // Assert
            var internalServerErrorResult = result.Should().BeOfType<ObjectResult>().Subject;
            internalServerErrorResult.StatusCode.Should().Be(500);
            internalServerErrorResult.Value.Should().Be("Internal server error: Something went wrong");
        }

        [Fact]
        public void CheckInPassengerInputModel_Should_Have_Validation_Errors_When_PassengerName_Is_Invalid()
        {
            // Arrange
            var inputModel = new CheckInPassengerInputModel
            {
                FlightId = 1,
                PassengerName = "JD",
                BaggageWeight = 20
            };

            // Act
            var validationResults = ValidateModel(inputModel);

            // Assert
            validationResults.Should().ContainSingle(v => v.ErrorMessage == "PassengerName must be at least 3 characters long.");
        }

        [Fact]
        public void CheckInPassengerInputModel_Should_Have_Validation_Errors_When_BaggageWeight_Is_Invalid()
        {
            // Arrange
            var inputModel = new CheckInPassengerInputModel
            {
                FlightId = 1,
                PassengerName = "John Doe",
                BaggageWeight = -1
            };

            // Act
            var validationResults = ValidateModel(inputModel);

            // Assert
            validationResults.Should().ContainSingle(v => v.ErrorMessage == "BaggageWeight cannot be a negative number");
        }
    }
}
