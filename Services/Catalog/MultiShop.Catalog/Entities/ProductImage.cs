using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public sealed class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductImageId { get; set; } = string.Empty;

    public List<string> Images { get; set; } = [];

    public string ProductId { get; set; } = string.Empty;
    [BsonIgnore] public Product Product { get; set; } = default!;
}