using IomarInn.Domain.ValueObjects;
using FluentAssertions;
namespace IomarInn.Domain.Tests;

public class CNPJTests
{
    [Fact (DisplayName = "CNPJ successful")]
    public void CreateCnpj_WithRightParameters_MustBeSuccessful()
    {
        Action action = () => new Cnpj("00600903000103");
        action.Should()
            .NotThrow<Validation.DomainExceptionValidation>();
    }
    
    [Fact (DisplayName = "CNPJ Wrong Parameters")]
    public void CreateCnpj_WithWrongParameters_MustHaveError()
    {
        Action action = () => new Cnpj("00600903330103");
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid CNPJ.");
    }
    
    [Fact (DisplayName = "CNPJ empty")]
    public void CreateCnpj_NoParameters_MustHaveError()
    {
        Action action = () => new Cnpj("");
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("CNPJ field cannot be blank.");
    }
}