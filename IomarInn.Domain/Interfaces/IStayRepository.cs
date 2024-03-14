using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Interfaces;

public interface IStayRepository
{
    Task<IEnumerable<Stay>> GetStays();
    Task<Stay> GetById(int? id);
    Task<Stay> Update(Stay stay);
    Task<Stay> Create(Stay stay);
    Task<Stay> Remove(Stay stay);
}