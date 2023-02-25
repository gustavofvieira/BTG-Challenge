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

        public async Task<Order> GetByIdAsync(Guid id) =>
            await _orderRepository.GetByIdAsync(id);

        public async Task<List<Order>> GetAllOrdersPublisher() =>
            await _orderRepository.GetAllOrdersPublisher();
    }
}
