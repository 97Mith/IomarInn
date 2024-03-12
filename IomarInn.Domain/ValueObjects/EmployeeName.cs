using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class EmployeeName
{
    public string FirstName { get; }
    public string? LastName { get; }

    public EmployeeName(string firstName, string? lastName = null)
    {
        ValidateMethods
            .IsNullOrEmpty(
                value: firstName, 
                message:"Name cannot be blank."
        );
        
        ValidateMethods
            .StringLengthLimits(
                value: firstName, 
                minimum: 2, maximum: 20, 
                message: "Name must have between 3 and 20 characters"
        );
        
        if (!string.IsNullOrEmpty(lastName))
        {
            ValidateMethods
                .StringLengthLimits(
                    value: lastName,
                    minimum: 2, maximum: 20,
                    message: "Last name must have between 2 and 20 characters."
            );
        }

        FirstName = firstName;
        LastName = lastName;

    }
}