using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class Cpf
{
    public string Value { get; private set; }

    public Cpf(string cpf)
    {
        ValidateMethods.ValidateCpf(
            value: cpf, 
            message:"Invalid CPF."
        );
    }
}