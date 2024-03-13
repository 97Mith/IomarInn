using IomarInn.Domain.Validation;

namespace IomarInn.Domain.Entities;

public sealed class Bedroom
{
    public int BedroomNumber { get; private set; }
    public List<int> GuestsIds { get; set; }
    public int CompanyId { get; set; }
    public int Capacity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }

    public void UpdateGuests(List<int> guestsIds)
    {
        ValidationMethods
            .FormatIntMaximum(
                value: guestsIds.Count, 
                maximum:Capacity, 
                message:"Capacity overflow."
            );
        GuestsIds = guestsIds;
    }

    public void UpdateCompanyId(int companyId)
    {
        CompanyId = companyId;
    }

    public void UpdatePrice(decimal price)
    {
        ValidationMethods
            .FormatPriceMinimum(
                value: price, 
                minimum:0, 
                message:"Price is invalid."
            );
        Price = price;
    }

    public void UpdateDiscount(decimal value)
    {
        ValidationMethods
            .FormatPriceMaximum(
                value: value, 
                maximum: Price, 
                message:"Discount must be less than price."
            );
        Discount = value;
    }

    public void UpdateCapacity(int value)
    {
        ValidationMethods
            .FormatIntMinimum(
                value: value, 
                minimum: 1, 
                message:"Capacity cannot be zero or negative."
            );
        Capacity = value;
    }
    public Bedroom(
        int id, 
        List<int> guestsIds, int companyId,
        int capacity,
        decimal price,
        decimal discount
        )
    {
        ValidationMethods
            .IdValidation(
                value: id, 
                message:"ID cannot be negative"
        );
        
        ValidationMethods
            .FormatIntMinimum(
                value: capacity, 
                minimum: 1, 
                message:"Capacity cannot be zero or negative."
        );
        
        ValidationMethods
            .FormatIntMaximum(
                value: guestsIds.Count, 
                maximum:capacity, 
                message:"Capacity overflow."
        );
        
        ValidationMethods
            .FormatPriceMinimum(
                value: price, 
                minimum:0, 
                message:"Price is invalid."
        ); 
        
        ValidationMethods
            .FormatPriceMaximum(
                value: discount, 
                maximum: price, 
                message:"Discount must be less than price."
        );

        BedroomNumber = id;
        GuestsIds = new List<int>(guestsIds);
        CompanyId = companyId;
        Capacity = capacity;
        Price = price;
        Discount = discount;

    }
}