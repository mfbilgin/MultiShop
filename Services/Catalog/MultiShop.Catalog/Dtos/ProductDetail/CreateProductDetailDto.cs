﻿namespace MultiShop.Catalog.Dtos.ProductDetail;

public sealed class CreateProductDetailDto
{
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductInfo { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
}