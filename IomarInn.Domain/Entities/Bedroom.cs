namespace IomarInn.Domain.Entities;

public sealed class Bedroom
{
    public int BedroomNumber { get; private set; }
    public List<int> GuestsIds { get; private set; }
    public int CompanyId { get; private set; }
    public int Capacity { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }
}