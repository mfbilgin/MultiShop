using MultiShop.Catalog.Dtos.Product;

namespace MultiShop.Catalog.Services.Product;

public interface IProductService
{
    Task<List<ProductResultDto>> GetAllAsync();
    Task<ProductGetByIdDto> GetByIdAsync(string productId);
    Task CreateAsync(ProductCreateDto productCreateDto);
    Task UpdateAsync(ProductUpdateDto productUpdateDto);
    Task DeleteAsync(string productId);
}