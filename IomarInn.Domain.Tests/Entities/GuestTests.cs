using FluentAssertions;
using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Tests.Entities
{
    public class GuestTests
    {
        [Fact(DisplayName = "Guest successful")]
        public void CreateGuest_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            int companyId = 1;
            string firstName = "John";
            string lastName = "Doe";
            string cpf = "12345678909";
            string phoneNumber = "+551234567890";

            // Act
            var guest = new Guest(id, companyId, firstName, lastName, cpf, phoneNumber);

            // Assert
            guest.Id.Should().Be(id);
            guest.CompanyId.Should().Be(companyId);
            guest.FullName.FirstName.Should().Be(firstName);
            guest.FullName.LastName.Should().Be(lastName);
            guest.Cpf.Value.Should().Be(cpf);
            guest.PhoneNumber.Value.Should().Be(phoneNumber);
        }

        [Fact(DisplayName = "Guest Negative ID")]
        public void CreateGuest_WithNegativeID_MustHaveError()
        {
            // Arrange
            int id = -1;
            int companyId = 1;
            string firstName = "John";
            string lastName = "Doe";
            string cpf = "12345678909";
            string phoneNumber = "+551234567890";

            // Act
            Action action = () => new Guest(id, companyId, firstName, lastName, cpf, phoneNumber);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("ID cannot be negative.");
        }

        [Fact(DisplayName = "Guest Negative Company ID")]
        public void CreateGuest_WithNegativeCompanyID_MustHaveError()
        {
            // Arrange
            int id = 1;
            int companyId = -1;
            string firstName = "John";
            string lastName = "Doe";
            string cpf = "12345678909";
            string phoneNumber = "+551234567890";

            // Act
            Action action = () => new Guest(id, companyId, firstName, lastName, cpf, phoneNumber);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Company ID cannot be negative.");
        }

        [Fact(DisplayName = "Guest Null CPF")]
        public void CreateGuest_WithNullCPF_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            int companyId = 1;
            string firstName = "John";
            string lastName = "Doe";
            string cpf = null; // Null CPF
            string phoneNumber = "+551234567890";

            // Act
            var guest = new Guest(id, companyId, firstName, lastName, cpf, phoneNumber);

            // Assert
            guest.Cpf.Should().BeNull();
        }

        [Fact(DisplayName = "Guest Null Phone Number")]
        public void CreateGuest_WithNullPhoneNumber_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            int companyId = 1;
            string firstName = "John";
            string lastName = "Doe";
            string cpf = "12345678909";
            string phoneNumber = null; // Null phone number

            // Act
            var guest = new Guest(id, companyId, firstName, lastName, cpf, phoneNumber);

            // Assert
            guest.PhoneNumber.Should().BeNull();
        }
    }
}
