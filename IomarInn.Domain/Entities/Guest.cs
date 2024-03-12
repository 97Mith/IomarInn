using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Guest
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public string Name { get; private set; }
    public Cpf Cpf { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    public Guest(int id)
    {
        Id = id;
    }

    public Guest(
        int id, 
        int companyId, 
        string name, 
        string cpf, 
        string phoneNumber
        )
    {
    }

    
}