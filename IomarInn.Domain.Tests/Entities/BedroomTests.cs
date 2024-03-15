using FluentAssertions;
using System.Collections.Generic;
using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Tests.Entities
{
    public class BedroomTests
    {
        [Fact(DisplayName = "Bedroom successful")]
        public void CreateBedroom_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            var guestsIds = new List<int> { 1, 2, 3 };
            int companyId = 1;
            int capacity = 3;
            decimal price = 100m;
            decimal discount = 10m;

            // Act
            var bedroom = new Bedroom(id, guestsIds, companyId, capacity, price, discount);

            // Assert
            bedroom.Id.Should().Be(id);
            bedroom.GuestsIds.Should().BeEquivalentTo(guestsIds);
            bedroom.CompanyId.Should().Be(companyId);
            bedroom.Capacity.Value.Should().Be(capacity);
            bedroom.Price.Value.Should().Be(price);
            bedroom.Discount.Value.Should().Be(discount);
        }

        [Fact(DisplayName = "Bedroom Capacity Overflow")]
        public void UpdateGuests_WithCapacityOverflow_MustHaveError()
        {
            // Arrange
            var bedroom = new Bedroom(1, new List<int>(), 1, 2, 100m, 0m);
            var guestsIds = new List<int> { 1, 2, 3 };

            // Act
            var action = () => bedroom.UpdateGuests(guestsIds);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Capacity overflow.");
        }

        [Fact(DisplayName = "Bedroom Discount Greater Than Price")]
        public void UpdateDiscount_WithDiscountGreaterThanPrice_MustHaveError()
        {
            // Arrange
            var bedroom = new Bedroom(1, new List<int>(), 1, 2, 100m, 0m);

            // Act
            var action = () => bedroom.UpdateDiscount(150m);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Discount must be less than price.");
        }
    }
}
