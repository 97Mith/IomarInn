using FluentAssertions;
using IomarInn.Domain.Entities;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.Entities
{
    public class CantinaOrderTests
    {
        [Fact(DisplayName = "CantinaOrder successful")]
        public void CreateCantinaOrder_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            var products = new List<Product>();
            int companyId = 1;

            // Act
            var cantinaOrder = new CantinaOrder(id, products, companyId);

            // Assert
            cantinaOrder.Id.Should().Be(id);
            cantinaOrder.Products.Should().BeEquivalentTo(products);
            cantinaOrder.CompanyId.Should().Be(companyId);
        }

        [Fact(DisplayName = "CantinaOrder Negative Company ID")]
        public void CreateCantinaOrder_WithNegativeCompanyID_MustHaveError()
        {
            // Arrange
            int id = 1;
            var products = new List<Product>();
            int companyId = -1; // Negative company ID

            // Act
            Action action = () => new CantinaOrder(id, products, companyId);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Company ID invalid.");
        }
    }
}