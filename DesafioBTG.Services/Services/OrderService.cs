using DesafioBTG.Domain.Interfaces.Repositories;
using DesafioBTG.Domain.Interfaces.Services;
using DesafioBTG.Domain.Models;

namespace DesafioBTG.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task AddOrder(Order order) => await _orderRepository.AddOrder(order);
        public async Task<Order> GetByIdAsync(string id) =>
            await _orderRepository.GetByIdAsync(id);

        public async Task<List<Order>> GetAllOrdersPublisher() =>
            await _orderRepository.GetAllOrdersPublisher();
        public async Task<int> GetTotalOrdersByCodeClient(int codeClient) => await _orderRepository.GetTotalOrdersByCodeClient(codeClient);
        public async Task<List<Order>> OrdersByClientList(int codeClient) => await _orderRepository.OrdersByClientList(codeClient);
        public async Task<double> GetTotalByCodeOrder(int codeOrder) => await _orderRepository.GetTotalByCodeOrder(codeOrder);



    }
}
