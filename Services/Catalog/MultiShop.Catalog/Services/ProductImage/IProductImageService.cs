using MultiShop.Catalog.Dtos.ProductImage;

namespace MultiShop.Catalog.Services.ProductImage;

public interface IProductImageService
{
    Task<List<ProductImageResultDto>> GetAllAsync();
    Task<ProductImageGetByIdDto> GetByIdAsync(string productImageId);
    Task CreateAsync(ProductImageCreateDto productImageCreateDto);
    Task UpdateAsync(ProductImageUpdateDto productImageUpdateDto);
    Task DeleteAsync(string productImageId);
}