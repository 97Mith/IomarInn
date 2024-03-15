using FluentAssertions;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class MaximumCapacityTests
    {
        [Fact(DisplayName = "MaximumCapacity successful")]
        public void CreateMaximumCapacity_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            int value = 5; // Example capacity within limits

            // Act
            Action action = () => new MaximumCapacity(value);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "MaximumCapacity Less Than Minimum")]
        public void CreateMaximumCapacity_LessThanMinimum_MustHaveError()
        {
            // Arrange
            int value = 0; // Value less than minimum (1)

            // Act
            Action action = () => new MaximumCapacity(value);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Capacity cannot be less than 1.");
        }

        [Fact(DisplayName = "MaximumCapacity Greater Than Maximum")]
        public void CreateMaximumCapacity_GreaterThanMaximum_MustHaveError()
        {
            // Arrange
            int value = 7; // Value greater than maximum (6)

            // Act
            Action action = () => new MaximumCapacity(value);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Capacity cannot be more than 6");
        }
    }
}