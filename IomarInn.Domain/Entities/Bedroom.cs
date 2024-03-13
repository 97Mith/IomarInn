using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Bedroom
{
    public int BedroomNumber { get; private set; }
    public List<int> GuestsIds { get; set; }
    public int CompanyId { get; set; }
    public int Capacity { get; private set; }
    public Price Price { get; private set; }
    public Discount Discount { get; private set; }

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
        Price = new Price(price);
    }

    public void UpdateDiscount(decimal value)
    {
        Discount = new Discount(discountValue: value, price: Price.Value);
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
            .FormatPriceMaximum(
                value: discount, 
                maximum: price, 
                message:"Discount must be less than price."
        );

        BedroomNumber = id;
        GuestsIds = new List<int>(guestsIds);
        CompanyId = companyId;
        Capacity = capacity;
        Price = new Price(price);
        Discount = new Discount(discountValue: discount, price: price);

    }
}