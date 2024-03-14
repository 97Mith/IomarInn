using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Laundry : EntityBase
{
    public int StayId{ get; set; }
    public string Obs { get; private set; }
    public List<Product> Cloathes { get; private set; }

    public Laundry(int id, int stayId, List<Product> cloathes, string obs = "...")
    {
        ValidationMethods
            .IdValidation(
                value:id, 
                message:"Laundry ID cannot be negative."
        );
        
        ValidationMethods
            .StringLengthLimits(
                value:obs, 
                minimum: 3, maximum: 500, 
                message:"Observaion must have between 4 and 500 caracters."
        );

        Id = id;
        StayId = stayId;
        Obs = obs;
        Cloathes = cloathes;
    }
}