using FluentAssertions;
using System.Collections.Generic;
using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Tests.Entities
{
    public class CompanyTests
    {
        [Fact(DisplayName = "Company successful")]
        public void CreateCompany_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            string name = "Test Company";
            string corporateReason = "Corporation XYZ";
            string cnpj = "00600903000103";
            string email = "test@example.com";
            string phoneNumber = "+551234567890";
            var employees = new List<Guest>();

            // Act
            var company = new Company(id, name, corporateReason, cnpj, email, phoneNumber, employees);

            // Assert
            company.Id.Should().Be(id);
            company.CompanyName.FantasyName.Should().Be(name);
            company.CompanyName.CorporateReason.Should().Be(corporateReason);
            company.Cnpj.Value.Should().Be(cnpj);
            company.Email.Value.Should().Be(email);
            company.PhoneNumber.Value.Should().Be(phoneNumber);
            company.Employees.Should().BeEquivalentTo(employees);
        }

        [Fact(DisplayName = "Company Negative ID")]
        public void CreateCompany_WithNegativeID_MustHaveError()
        {
            // Arrange
            int id = -1;
            string name = "Test Company";
            string corporateReason = "Corporation XYZ";
            string cnpj = "00600903000103";
            string email = "test@example.com";
            string phoneNumber = "+551234567890";
            var employees = new List<Guest>();

            // Act
            Action action = () => new Company(id, name, corporateReason, cnpj, email, phoneNumber, employees);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("ID cannot be negative.");
        }

        [Fact(DisplayName = "Company Null Email")]
        public void CreateCompany_WithNullEmail_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            string name = "Test Company";
            string corporateReason = "Corporation XYZ";
            string cnpj = "00600903000103";
            string email = null; // Null email
            string phoneNumber = "+551234567890";
            var employees = new List<Guest>();

            // Act
            var company = new Company(id, name, corporateReason, cnpj, email, phoneNumber, employees);

            // Assert
            company.Email.Should().BeNull();
        }

        [Fact(DisplayName = "Company Null Phone Number")]
        public void CreateCompany_WithNullPhoneNumber_MustBeSuccessful()
        {
            // Arrange
            int id = 1;
            string name = "Test Company";
            string corporateReason = "Corporation XYZ";
            string cnpj = "00600903000103";
            string email = "test@example.com";
            string phoneNumber = null; // Null phone number
            var employees = new List<Guest>();

            // Act
            var company = new Company(id, name, corporateReason, cnpj, email, phoneNumber, employees);

            // Assert
            company.PhoneNumber.Should().BeNull();
        }
    }
}
