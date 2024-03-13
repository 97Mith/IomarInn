using System.Net.Mail;
using IomarInn.Domain.Validation;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Company
{
    public int Id { get; private set; }
    public CompanyName CompanyName { get; private set; }
    public Cnpj Cnpj { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public ICollection<Guest> Employees { get; private set; }
    
    public Company(int id)
    {
        ValidationMethods.IdValidation(
            value: id, 
            message:"ID cannot be negative."
        );
        Id = id;
    }

    public Company(
        int id, 
        string name, string corporateReason, 
        string cnpj, 
        string? email, 
        string? phoneNumber,
        ICollection<Guest> employees
        )
    {
        ValidationMethods
            .IdValidation(
                value: id, 
                message:"ID cannot be negative."
        );
        Id = id;
        
        CompanyName = new CompanyName(fantasyName: name, corporateReason: corporateReason);
        
        Cnpj = new Cnpj(cnpj);
        
        if (email != null)
            Email = new Email(email);

        if (phoneNumber != null)
            PhoneNumber = new PhoneNumber(phoneNumber);

        Employees = new List<Guest>(employees);
    }
    public void UpdateName(string companyName, string corporateReason)
    {
        CompanyName = new CompanyName(
            fantasyName: companyName, 
            corporateReason: corporateReason
        );
    }
    
    public void UpdateEmail(string value)
    {
        Email = new Email(value);
    }

    public void UpdatePhoneNumber(string value)
    {
        PhoneNumber = new PhoneNumber(value);
    }

    public void UpdateEmployees(ICollection<Guest> guests)
    {
        Employees = new List<Guest>(guests);
    }
}