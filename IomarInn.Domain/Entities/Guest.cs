using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Guest
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public EmployeeName FullName { get; private set; }
    public Cpf? Cpf { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    
    public Guest(
        int id, int companyId, 
        string firstName, string? lastName,
        string? cpf, 
        string? phoneNumber
        )
    {
        ValidationMethods.IdValidation(
            value: id, 
            message:"ID cannot be negative."
        );
        Id = id;

        ValidationMethods.IdValidation(
            value: companyId, 
            message:"Company ID cannot be negative."
        );
        CompanyId = companyId;

        FullName = new EmployeeName(firstName: firstName, lastName: lastName);

        if (cpf != null)
            Cpf = new Cpf(cpf);

        if (phoneNumber != null)
            PhoneNumber = new PhoneNumber(phoneNumber);
    }

    
}