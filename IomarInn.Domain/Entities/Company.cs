using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CorporateReason { get; set; }
    public Cnpj Cnpj { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public ICollection<Guest> Employee { get; set; }
}