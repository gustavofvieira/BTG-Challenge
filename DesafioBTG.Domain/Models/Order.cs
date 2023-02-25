using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace DesafioBTG.Domain.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string _id { get; set; } = default!;

        [BsonElement("codigoPedido")]
        [JsonPropertyName("codigoPedido")]
        public int CodeOrder { get; set; }

        [BsonElement("codigoCliente")]
        [JsonPropertyName("codigoCliente")]
        public int CodeClient { get; set; }

        [BsonElement("itens")]
        [JsonPropertyName("itens")]
        public List<Item> Itens { get; set; } = default!;

    }
}
