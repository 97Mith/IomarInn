using System.Net.Mail;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Company
{
    public int Id { get; private set; }
    public CompanyName CompanyName { get; private set; }
    public Cnpj Cnpj { get; private set; }
    public MailAddress Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public ICollection<Guest> Employees { get; private set; }

    public Company(int id)
    {
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
        Id = id;
        
        CompanyName = new CompanyName(fantasyName: name, corporateReason: corporateReason);
        
        Cnpj = new Cnpj(cnpj);
        
        if (email != null)
            Email = new MailAddress(email);

        if (phoneNumber != null)
            PhoneNumber = new PhoneNumber(phoneNumber);

        Employees = new List<Guest>(employees);
    }
    
}