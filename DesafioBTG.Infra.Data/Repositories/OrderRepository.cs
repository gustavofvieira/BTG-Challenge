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

        public async Task AddOrder(Order order) => await _context.Orders.InsertOneAsync(order);
        public async Task<int> GetTotalOrdersByCodeClient(int codeClient) =>
            await _context.Orders.AsQueryable().CountAsync(o => o.CodeClient.Equals(codeClient));
        public async Task<List<Order>> OrdersByClientList(int codeClient) =>
            await _context.Orders.AsQueryable().Where(o => o.CodeClient.Equals(codeClient)).ToListAsync();

        public async Task<Order> GetTotalByCodeOrder(int codeOrder) => 
            await _context.Orders.AsQueryable().Where(o => o.CodeOrder.Equals(codeOrder)).FirstOrDefaultAsync();


    }
}
