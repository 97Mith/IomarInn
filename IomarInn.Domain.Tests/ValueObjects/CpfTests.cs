using FluentAssertions;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class CpfTests
    {
        [Fact(DisplayName = "CPF successful")]
        public void CreateCpf_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            string cpf = "12345678909"; // Example CPF

            // Act
            Action action = () => new Cpf(cpf);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CPF Wrong Parameters")]
        public void CreateCpf_WithWrongParameters_MustHaveError()
        {
            // Arrange
            string cpf = "1234567890"; // Invalid CPF (length less than 11)

            // Act
            Action action = () => new Cpf(cpf);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid CPF.");
        }

        [Fact(DisplayName = "CPF No Value")]
        public void CreateCpf_WithNullValue_MustHaveError()
        {
            // Arrange
            string cpf = "";

            // Act
            Action action = () => new Cpf(cpf);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid CPF.");
        }
    }
}