using MongoDB.Bson.Serialization.Attributes;

namespace DesafioBTG.Domain.Models
{
    public class Order
    {
        [BsonId]
        public Guid Id { get; set; }
        public int CodigoPedido { get; set; }
        public int CodigoCliente { get; set; }
        public List<Item> Itens { get; set; }

    }
}
