using System.Net.Mail;
using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class Email
{
    public MailAddress Value { get; }

    public Email(string value)
    {
        ValidationMethods
            .IsNullOrEmpty(
                value:value, 
                message:"Email cannot be blank"
        );
        
        ValidationMethods
            .StringLengthLimits(
                value: value, 
                minimum: 4, maximum: 20,
                message: "The email must have between 5 and 20 characters"
        );

        Value = new MailAddress(value);
    }
}