namespace IomarInn.Domain.Entities;

public class Bedroom
{
    public int BedroomNumber { get; set; }
    public List<int> GuestsIds { get; set; }
    public int CompanyId { get; set; }
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}