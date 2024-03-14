using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Guest : EntityBase
{
    public int CompanyId { get; set; }
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

    public void UpdateName(string firstName, string lastName)
    {
        FullName = new EmployeeName(firstName: firstName, lastName: lastName);
    }

    public void UpdateCpf(string value)
    {
        Cpf = new Cpf(value);
    }

    public void UpdatePhoneNumber(string value)
    {
        PhoneNumber = new PhoneNumber(value);
    }
    
}