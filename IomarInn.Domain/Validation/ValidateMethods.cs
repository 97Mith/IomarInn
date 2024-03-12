using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Validation;

public class ValidateMethods
{
    public static void IsNullOrEmpty(string value, string message)
    {
        DomainExceptionValidation
            .When(
                hasError : string.IsNullOrEmpty(value),
                error: message
            );
    }
    
    public static void StringLengthLimits(string value, int minimum, int maximum, string message)
    {
        DomainExceptionValidation
            .When(
                hasError : value.Length < minimum,
                error: message
            );
        DomainExceptionValidation
            .When(
                hasError : value.Length > maximum,
                error: message
            );
    }

    public static void CnpjValidation(string value, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: !Methods.IsCnpj(value),
                error: message
            );
    }

    public static void CpfValidation(string value, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: !Methods.IsCpf(value), 
                error: message
            );
    }

    public static void PhoneNumberValidation(string phoneNumber, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: !Methods.IsPhoneNumber(phoneNumber),
                error: message
            );
    }
}