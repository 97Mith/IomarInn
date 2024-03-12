using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class Cnpj
{
    public string Value { get; private set; }
    
    public Cnpj(string cnpj)
    {
        ValidateMethods
            .IsNullOrEmpty(
                value: cnpj, 
                message:"CNPJ field cannot be blank."
        );
        
        ValidateMethods
            .ValidateCnpj(
                value: cnpj, 
                message: "Invalid CNPJ."
        );
        
    }
}