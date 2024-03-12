using System.Net.Mail;
using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public sealed class Company
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string CorporateReason { get; private set; }
    public Cnpj Cnpj { get; private set; }
    public MailAddress Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public ICollection<Guest> Employee { get; private set; }

    public Company(int id)
    {
        Id = id;
    }

    public Company(
        string name, 
        string corporateReason, 
        string cnpj, 
        string email, 
        string phoneNumber
        )
    {
        
    }

    public Company(ICollection<Guest> employee)
    {
        
    }
}