using FluentAssertions;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class PhoneNumberTests
    {
        [Fact(DisplayName = "PhoneNumber successful")]
        public void CreatePhoneNumber_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            string phoneNumber = "+5541998374058"; // Example phone number

            // Act
            Action action = () => new PhoneNumber(phoneNumber);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "PhoneNumber Null Value")]
        public void CreatePhoneNumber_WithNullValue_MustHaveError()
        {
            // Arrange
            string phoneNumber = "";

            // Act
            Action action = () => new PhoneNumber(phoneNumber);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Phone Number is invalid.");
        }

        [Fact(DisplayName = "PhoneNumber Wrong Format")]
        public void CreatePhoneNumber_WithWrongFormat_MustHaveError()
        {
            // Arrange
            string phoneNumber = "123456789"; // Invalid format (less than 10 digits)

            // Act
            Action action = () => new PhoneNumber(phoneNumber);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Phone Number is invalid.");
        }
    }
}