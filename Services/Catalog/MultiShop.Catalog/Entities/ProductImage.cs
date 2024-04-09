﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductImageId { get; set; }

    [BsonRepresentation(BsonType.Array)]
    public List<string> Images { get; set; }

    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}