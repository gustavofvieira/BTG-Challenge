using DesafioBTG.Domain.Models;

namespace DesafioBTG.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task<Order> GetTotalByCodeOrder(int codeOrder);
        Task<int> GetTotalOrdersByCodeClient(int codeClient);
        Task<List<Order>> OrdersByClientList(int codeClient);
    }
}
