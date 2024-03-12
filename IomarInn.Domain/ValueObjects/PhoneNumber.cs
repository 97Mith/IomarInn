using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class PhoneNumber
{
    public string Value { get; private set; }

    public PhoneNumber(string value)
    {
        ValidationMethods
            .PhoneNumberValidation(
                phoneNumber: value, 
                message: "Phone Number is invalid."
            );

        Value = value;
    }
}