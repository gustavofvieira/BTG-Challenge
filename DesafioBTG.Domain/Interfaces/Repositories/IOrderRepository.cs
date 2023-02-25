using DesafioBTG.Domain.Models;

namespace DesafioBTG.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task<List<Order>> GetAllOrdersPublisher();
    }
}
