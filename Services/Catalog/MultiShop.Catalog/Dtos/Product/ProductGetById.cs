namespace MultiShop.Catalog.Dtos.Product;

public class ProductGetById
{
    public string ProductId { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public decimal ProductPrice { get; set; }
    
    public int ProductStock { get; set; }
    
    public string ProductImageUrl { get; set; } = string.Empty;
    
    public string ProductDescription { get; set; } = string.Empty;

    public string CategoryId { get; set; } = string.Empty;
}