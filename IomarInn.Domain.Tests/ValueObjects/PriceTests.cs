using FluentAssertions;
using IomarInn.Domain.ValueObjects;
using Xunit;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class PriceTests
    {
        [Fact(DisplayName = "Price successful")]
        public void CreatePrice_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            decimal value = 10.50m;

            // Act
            Action action = () => new Price(value);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Price Negative Value")]
        public void CreatePrice_WithNegativeValue_MustHaveError()
        {
            // Arrange
            decimal value = -10.50m;

            // Act
            Action action = () => new Price(value);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Price is invalid.");
        }

        [Fact(DisplayName = "Price Zero Value")]
        public void CreatePrice_WithZeroValue_MustBeSuccessful()
        {
            // Arrange
            decimal value = 0m;

            // Act
            Action action = () => new Price(value);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }
    }
}