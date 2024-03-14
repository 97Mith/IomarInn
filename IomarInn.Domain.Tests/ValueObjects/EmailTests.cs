using FluentAssertions;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact(DisplayName = "Email successful")]
        public void CreateEmail_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            string email = "test@example.com";

            // Act
            Action action = () => new Email(email);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Email Wrong Parameters")]
        public void CreateEmail_WithWrongParameters_MustHaveError()
        {
            // Arrange
            string email = "";

            // Act
            Action action = () => new Email(email);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Email cannot be blank");
        }

        [Fact(DisplayName = "Email Length Limits")]
        public void CreateEmail_WithLengthOutOfLimits_MustHaveError()
        {
            // Arrange
            string email = "am"; // Length less than minimum (4)

            // Act
            Action action = () => new Email(email);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("The email must have between 5 and 20 characters");
        }
    }
}