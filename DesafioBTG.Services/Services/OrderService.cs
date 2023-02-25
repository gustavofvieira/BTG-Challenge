using DesafioBTG.Domain.Interfaces.Repositories;
using DesafioBTG.Domain.Interfaces.Services;
using DesafioBTG.Domain.Models;
using DesafioBTG.Infra.Data.MassOfData;
using System.Text.Json;

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

        public List<Order> GetAllOrdersPublisher()
        {
            string jsonString = MassOrders.Mass;

            List<Order> ordersPublisher = JsonSerializer.Deserialize<List<Order>>(jsonString)!;
           
            return ordersPublisher;
        }
            
        public async Task<int> GetTotalOrdersByCodeClient(int codeClient) => await _orderRepository.GetTotalOrdersByCodeClient(codeClient);
        public async Task<List<Order>> OrdersByClientList(int codeClient) => await _orderRepository.OrdersByClientList(codeClient);
        public async Task<double> GetTotalByCodeOrder(int codeOrder)
        {
            var order = await _orderRepository.GetTotalByCodeOrder(codeOrder);
            double totalOrder = 0;
            foreach (var item in order.Itens)
            {
                totalOrder += (item.Price * item.Amout);
            }
            return totalOrder;
        }



    }
}
