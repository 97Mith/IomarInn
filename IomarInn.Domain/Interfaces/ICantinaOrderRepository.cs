using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Interfaces;

public interface ICantinaOrderRepository
{
    Task<IEnumerable<CantinaOrder>> GetCantinaOrders();
    Task<CantinaOrder> GetById(int? id);
    Task<CantinaOrder> Update(CantinaOrder cantinaOrder);
    Task<CantinaOrder> Create(CantinaOrder cantinaOrder);
    Task<CantinaOrder> Remove(CantinaOrder cantinaOrder);
}