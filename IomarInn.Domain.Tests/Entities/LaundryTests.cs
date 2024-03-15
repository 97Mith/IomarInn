using FluentAssertions;
using IomarInn.Domain.Entities;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.Entities
{
    public class LaundryTests
    {
        [Fact(DisplayName = "Laundry successful")]
        public void CreateLaundry_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            int stayId = 1;
            var cloathes = new List<Product>();
            string obs = "Test observation";

            // Act
            var laundry = new Laundry(id, stayId, cloathes, obs);

            // Assert
            laundry.Id.Should().Be(id);
            laundry.StayId.Should().Be(stayId);
            laundry.Obs.Should().Be(obs);
            laundry.Cloathes.Should().BeEquivalentTo(cloathes);
        }

        [Fact(DisplayName = "Laundry Negative ID")]
        public void CreateLaundry_WithNegativeID_MustHaveError()
        {
            // Arrange
            int id = -1;
            int stayId = 1;
            var cloathes = new List<Product>();
            string obs = "Test observation";

            // Act
            Action action = () => new Laundry(id, stayId, cloathes, obs);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Laundry ID cannot be negative.");
        }

        [Fact(DisplayName = "Laundry Obs Length Limits")]
        public void CreateLaundry_WithObsOutOfLengthLimits_MustHaveError()
        {
            // Arrange
            int id = 1;
            int stayId = 1;
            var cloathes = new List<Product>();
            string obs = "Te"; // Length less than minimum (3)

            // Act
            Action action = () => new Laundry(id, stayId, cloathes, obs);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Observaion must have between 4 and 500 caracters.");
        }
    }
}