using DesafioBTG.Domain.Models;
using MongoDB.Driver;

namespace DesafioBTG.Infra.Data.Context
{
    public class OrderContext
    {
        public OrderContext(IMongoDatabase database) => Database = database;

        public IMongoDatabase Database { get; private set; }

        public IMongoCollection<Order> Orders => Database.GetCollection<Order>("Order");
        public IMongoCollection<Order> OrdersProducer => Database.GetCollection<Order>("OrderProducer");
    }
}
