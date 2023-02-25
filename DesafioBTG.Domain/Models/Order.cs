using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DesafioBTG.Domain.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("codigoPedido")]
        public int CodigoPedido { get; set; }

        [BsonElement("codigoCliente")]
        public int CodigoCliente { get; set; }

        [BsonElement("itens")]
        public List<Item> Itens { get; set; }

    }
}
