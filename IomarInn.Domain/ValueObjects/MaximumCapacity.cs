using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class MaximumCapacity
{
    public int Value { get; private set; }

    public MaximumCapacity(int value)
    {
        ValidationMethods
            .FormatIntMinimum(
                value: value, 
                minimum: 1, 
                message:"Capacity cannot be less than 1."
        );
        
        ValidationMethods
            .FormatIntMaximum(
                value: value, 
                maximum: 6, 
                message:"Capacity cannot be more than 6"
        );

        Value = value;
    }
}