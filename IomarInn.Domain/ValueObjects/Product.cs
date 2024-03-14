using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public sealed class Product
{
    public int Quantity { get; private set; }
    public string Descripton { get; private set; }
    public Price UnitaryPrice { get; private set; }
    public decimal TotalValue { get; private set; }

    public Product(int quantity, string descripton, decimal price)
    {
        ValidationMethods
            .FormatIntMinimum(
                value: quantity, 
                minimum:1, 
                message:"Must have at least 1 product"
        );
        
        ValidationMethods
            .IsNullOrEmpty(
                value: descripton, 
                message: "Description must be informed."
        );
        
        ValidationMethods
            .StringLengthLimits(
                value: descripton, 
                minimum: 4, maximum: 30, 
                message:"Description must have between 5 and 30 characters."
        );

        Quantity = quantity;
        Descripton = descripton;
        UnitaryPrice = new Price(price);
        TotalValue = quantity * price;
    }
}