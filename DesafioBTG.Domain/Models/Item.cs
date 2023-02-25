using MongoDB.Bson.Serialization.Attributes;

namespace DesafioBTG.Domain.Models
{
    public class Item
    {
        [BsonElement("produto")]
        public string Product { get; set; }

        [BsonElement("quantidade")]
        public int Amout { get; set; }

        [BsonElement("preco")]
        public double Price { get; set; }
    }
}
