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
        public int CodeOrder { get; set; }

        [BsonElement("codigoCliente")]
        public int CodeClient { get; set; }

        [BsonElement("itens")]
        public List<Item> Itens { get; set; }

    }
}
