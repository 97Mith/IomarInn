using FluentAssertions;
using IomarInn.Domain.ValueObjects;
using Xunit;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class ProductTests
    {
        [Fact(DisplayName = "Product successful")]
        public void CreateProduct_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            int quantity = 2;
            string description = "Test Product";
            decimal price = 10.50m;

            // Act
            Action action = () => new Product(quantity, description, price);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Product Quantity Less Than Minimum")]
        public void CreateProduct_WithQuantityLessThanMinimum_MustHaveError()
        {
            // Arrange
            int quantity = 0; // Less than minimum (1)
            string description = "Test Product";
            decimal price = 10.50m;

            // Act
            Action action = () => new Product(quantity, description, price);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Must have at least 1 product");
        }

        [Fact(DisplayName = "Product Null Description")]
        public void CreateProduct_WithNullDescription_MustHaveError()
        {
            // Arrange
            int quantity = 2;
            string description = null; // Null description
            decimal price = 10.50m;

            // Act
            Action action = () => new Product(quantity, description, price);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Description must be informed.");
        }

        [Fact(DisplayName = "Product Description Length Limits")]
        public void CreateProduct_WithDescriptionOutOfLengthLimits_MustHaveError()
        {
            // Arrange
            int quantity = 2;
            string description = "Prod"; // Length less than minimum (4)
            decimal price = 10.50m;

            // Act
            Action action = () => new Product(quantity, description, price);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Description must have between 5 and 30 characters.");
        }
    }
}
