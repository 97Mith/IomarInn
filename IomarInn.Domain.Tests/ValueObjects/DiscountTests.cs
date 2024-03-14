using FluentAssertions;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class DiscountTests
    {
        [Fact(DisplayName = "Discount successful")]
        public void CreateDiscount_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            decimal discountValue = 5m;
            decimal price = 10m;

            // Act
            Action action = () => new Discount(discountValue, price);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Discount Negative Value")]
        public void CreateDiscount_WithNegativeValue_MustHaveError()
        {
            // Arrange
            decimal discountValue = -5m;
            decimal price = 10m;

            // Act
            Action action = () => new Discount(discountValue, price);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Discount cannot be negative.");
        }

        [Fact(DisplayName = "Discount Greater Than Price")]
        public void CreateDiscount_GreaterThanPrice_MustHaveError()
        {
            // Arrange
            decimal discountValue = 15m;
            decimal price = 10m;

            // Act
            Action action = () => new Discount(discountValue, price);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Discount must be less than price.");
        }
    }
}