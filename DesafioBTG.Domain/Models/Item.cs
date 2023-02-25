using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace DesafioBTG.Domain.Models
{
    public class Item
    {
        [BsonElement("produto")]
        [JsonPropertyName("produto")]
        public string Product { get; set; } = default!;

        [BsonElement("quantidade")]
        [JsonPropertyName("quantidade")]
        public int Amout { get; set; }

        [BsonElement("preco")]
        [JsonPropertyName("preco")]
        public double Price { get; set; }
    }
}
