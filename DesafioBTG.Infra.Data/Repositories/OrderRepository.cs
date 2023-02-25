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

        public async Task<Order> GetByIdAsync(Guid id) =>
            await _context.Orders
                .AsQueryable()
                .SingleAsync(b => b.Id == id);
        public async Task<List<Order>> GetAllOrdersPublisher() => 
            await _context.OrdersProducer
            .AsQueryable()
            .ToListAsync();
    }
}
