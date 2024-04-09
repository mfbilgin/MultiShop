using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public sealed class Category
{
     [BsonId]
     [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;
    
    
}
