﻿namespace MultiShop.Catalog.Dtos.ProductImage;

public sealed class ProductImageResultDto
{
    public string ProductImageId { get; set; } = string.Empty;

    public List<string> Images { get; set; } = [];

    public string ProductId { get; set; } = string.Empty;
}