using IomarInn.Domain.ValueObjects;

namespace IomarInn.Domain.Entities;

public class Guest
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public Cpf Cpf { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
}