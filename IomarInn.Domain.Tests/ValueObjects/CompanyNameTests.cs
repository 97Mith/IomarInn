using FluentAssertions;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Tests.ValueObjects
{
    public class CompanyNameTests
    {
        [Fact(DisplayName = "CompanyName successful")]
        public void CreateCompanyName_WithRightParameters_MustBeSuccessful()
        {
            // Arrange
            string fantasyName = "Company XYZ";
            string corporateReason = "Corporation XYZ";

            // Act
            Action action = () => new CompanyName(fantasyName, corporateReason);

            // Assert
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CompanyName FantasyName Wrong Parameters")]
        public void CreateCompanyName_WithWrongFantasyName_MustHaveError()
        {
            // Arrange
            string fantasyName = "";
            string corporateReason = "Corporation XYZ";

            // Act
            Action action = () => new CompanyName(fantasyName, corporateReason);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Name cannot be blank.");
        }

        [Fact(DisplayName = "CompanyName CorporateReason Wrong Parameters")]
        public void CreateCompanyName_WithWrongCorporateReason_MustHaveError()
        {
            // Arrange
            string fantasyName = "Company XYZ";
            string corporateReason = "";

            // Act
            Action action = () => new CompanyName(fantasyName, corporateReason);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Corporate Reason cannot be blank.");
        }

        [Fact(DisplayName = "CompanyName FantasyName Length Limits")]
        public void CreateCompanyName_WithFantasyNameOutOfLengthLimits_MustHaveError()
        {
            // Arrange
            string fantasyName = "XYZ"; // Length less than minimum (5)
            string corporateReason = "Corporation XYZ";

            // Act
            Action action = () => new CompanyName(fantasyName, corporateReason);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Name must have between 6 and 35 characters");
        }

        [Fact(DisplayName = "CompanyName CorporateReason Length Limits")]
        public void CreateCompanyName_WithCorporateReasonOutOfLengthLimits_MustHaveError()
        {
            // Arrange
            string fantasyName = "Company XYZ";
            string corporateReason = "XYZ"; // Length less than minimum (6)

            // Act
            Action action = () => new CompanyName(fantasyName, corporateReason);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Corporate Reason must have between 7 and 50 characters.");
        }
    }
}
