using DesafioBTG.Domain.Models;

namespace DesafioBTG.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Order> GetByIdAsync(Guid id);
        Task<List<Order>> GetAllOrdersPublisher();
    }
}
