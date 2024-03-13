using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Validation;

public class ValidationMethods
{
    public static void IdValidation(int value, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: value < 0, 
                error: message
        );
    }

    public static void FormatPriceMinimum(decimal value, decimal minimum, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: value < minimum, 
                error: message
        );
    }
    
    public static void FormatIntMinimum(int value, int minimum, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: value < minimum, 
                error: message
        );
    }
    public static void FormatIntMaximum(int value, int maximum, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: value > maximum, 
                error: message
        );
    }
    
    public static void FormatPriceMaximum(decimal value, decimal maximum, string message)
    {
        DomainExceptionValidation
            .When(
                hasError: value > maximum, 
                error: message
            );
    }
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