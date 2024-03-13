using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class Price
{
    public decimal Value { get; private set; }

    public Price(decimal value)
    {
        ValidationMethods
            .FormatPriceMinimum(
                value: value, 
                minimum:0, 
                message:"Price is invalid."
        );

        Value = value;
    }
}