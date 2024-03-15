using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public sealed class CheckOut
{
    public DateTime Value { get; private set; }

    public CheckOut(DateTime checkIn, DateTime checkOut)
    {
        DomainExceptionValidation.When(
            hasError: !Methods.IsCheckOutAfterCheckIn(checkIn: checkIn, checkOut: checkOut),
            error: "CheckOut cannot be before CheckIn date."
        );

        Value = checkOut;

    }
}