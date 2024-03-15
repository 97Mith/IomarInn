using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Stay : EntityBase
{
    public int? LaundryId { get; set; }
    public Bedroom Bedroom { get; private set; }
    public List<Product>? Products { get; private set; }
    public DateTime CheckIn { get; private set; }
    public CheckOut? CheckOut { get; private set; }
    public int? DaysOfStay { get; private set; }
    public decimal TotalExpense { get; private set; }

    public Stay(
        int? laundryId, 
        Bedroom bedroom, 
        List<Product>? products, 
        DateTime checkIn, 
        CheckOut? checkOut
    )
    {
        if (checkOut != null)
        {
            DaysOfStay = 
                Methods
                    .CalculateStayDuration(
                        checkIn: checkIn, 
                        checkOut: checkOut.Value
            );

            TotalExpense = ((decimal)DaysOfStay * bedroom.Price.Value) + ;
        }
        LaundryId = laundryId;
        Bedroom = bedroom;
        Products = products;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }
    
}