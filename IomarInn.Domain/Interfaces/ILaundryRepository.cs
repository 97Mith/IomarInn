using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Interfaces;

public interface ILaundryRepository
{
    Task<IEnumerable<Laundry>> GetLaundries();
    Task<Laundry> GetById(int? id);
    Task<Laundry> Create(Laundry laundry);
    Task<Laundry> Update(Laundry laundry);
    Task<Laundry> Remove(Laundry laundry);
}