using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Interfaces;

public interface IGuestRepository
{
    Task<IEnumerable<Guest>> GetGuests();
    Task<Guest> GetById(int? id);
    Task<Guest> Create(Guest guest);
    Task<Guest> Update(Guest guest);
    Task<Guest> Remove(Guest guest);
}