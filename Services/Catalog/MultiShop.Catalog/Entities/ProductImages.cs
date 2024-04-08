using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductImages
{
     [BsonId]
     [BsonRepresentation(BsonType.ObjectId)]
    public string ProductImagesId { get; set; }
}