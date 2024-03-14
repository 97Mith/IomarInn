using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Stay : EntityBase
{
    public int LaundryId { get; set; }
    public Bedroom Bedroom { get; private set; }
    public List<Product> Products { get; private set; }
    //TODO criar VO para checkin e checkout
}