namespace MultiShop.Catalog.Dtos.ProductImage;

public sealed class ProductImageCreateDto
{
    public List<string> Images { get; set; } = [];

    public string ProductId { get; set; } = string.Empty;
}