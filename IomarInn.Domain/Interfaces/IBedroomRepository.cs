using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Interfaces;

public interface IBedroomRepository
{
    Task<IEnumerable<Bedroom>> GetBedroons();
    Task<Bedroom> GetById(int? id);
    Task<Bedroom> Create(Bedroom bedroom);
    Task<Bedroom> Update(Bedroom bedroom);
    Task<Bedroom> Remove(Bedroom bedroom);

}