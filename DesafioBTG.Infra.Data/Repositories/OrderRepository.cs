using DesafioBTG.Domain.Interfaces.Repositories;
using DesafioBTG.Domain.Models;
using DesafioBTG.Infra.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DesafioBTG.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrderContext _context;
        public OrderRepository(
            OrderContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(string id) =>
            await _context.Orders
                .AsQueryable()
                .SingleAsync(b => b._id == id);
        public async Task<List<Order>> GetAllOrdersPublisher() => 
            await _context.OrdersProducer
            .AsQueryable()
            .ToListAsync();
        public async Task<int> GetTotalOrdersByCodeClient(int codeClient) =>
            await _context.OrdersProducer.AsQueryable().CountAsync(o => o.CodeClient.Equals(codeClient));
        public async Task<List<Order>> OrdersByClientList(int codeClient) =>
            await _context.OrdersProducer.AsQueryable().Where(o => o.CodeClient.Equals(codeClient)).ToListAsync();

        public async Task<double> GetTotalByCodeOrder(int codeOrder)
        {
            var order = await _context.OrdersProducer.AsQueryable().Where(o => o.CodeOrder.Equals(codeOrder)).FirstOrDefaultAsync();

            double totalOrder = 0;
            foreach (var item in order.Itens)
            {
                totalOrder += item.Price;
            }
            return totalOrder;
        }
    }
}
