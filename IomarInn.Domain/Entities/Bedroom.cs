using IomarInn.Domain.Validation;

namespace IomarInn.Domain.Entities;

public sealed class Bedroom
{
    public int BedroomNumber { get; private set; }
    public List<int> GuestsIds { get; private set; }
    public int CompanyId { get; private set; }
    public int Capacity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }

    public Bedroom(
        int id, List<int> guestsIds, int companyId,
        int capacity,
        decimal price,
        decimal discount
        )
    {
        DomainExceptionValidation
            .When(
                hasError: id < 0, 
                error: "ID cannot be negative." 
            );
        
        DomainExceptionValidation
            .When(
                hasError: capacity < 1,
                error: "Capacity cannot be zero or negative."
            );
        
        DomainExceptionValidation
            .When(
                hasError: guestsIds.Count > capacity,
                error: "Capacity overflow."
            );
        
        DomainExceptionValidation
            .When(
                hasError: price < 0,
                error: "Price cannot be negative."
            );
        
        DomainExceptionValidation
            .When(
                hasError: discount > price,
                error: "Discount must be less than price."
            );
        
        BedroomNumber = id;
        GuestsIds = new List<int>(guestsIds);
        CompanyId = companyId;
        Capacity = capacity;
        Price = price;
        Discount = discount;

    }
}