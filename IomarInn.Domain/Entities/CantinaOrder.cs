using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class CantinaOrder : EntityBase
{
    private List<Product> Products { get; }
    private int CompanyId { get; set; }

    public CantinaOrder(int id, List<Product> products, int companyId)
    {
        ValidationMethods
            .IdValidation(
                value: companyId, 
                message:"Company ID invalid."
        );

        Id = id;
        CompanyId = id;
        Products = products;
    }
}