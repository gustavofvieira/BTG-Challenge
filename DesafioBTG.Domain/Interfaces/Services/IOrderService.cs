using DesafioBTG.Domain.Models;

namespace DesafioBTG.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
        List<Order> GetAllOrdersPublisher();
        Task<double> GetTotalByCodeOrder(int codeOrder);
        Task<int> GetTotalOrdersByCodeClient(int codeClient);
        Task<List<Order>> OrdersByClientList(int codeClient);
    }
}
