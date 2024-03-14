using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class Discount
{
    public decimal Value { get; private set; }

    public Discount(decimal discountValue, decimal price)
    {
        ValidationMethods
            .FormatPriceMinimum(
                value: discountValue,
                minimum: 0,
                message:"Discount cannot be negative." 
        );
        
        ValidationMethods
            .FormatPriceMaximum(
                value: discountValue, 
                maximum: price, 
                message:"Discount must be less than price."
            );
    }
}