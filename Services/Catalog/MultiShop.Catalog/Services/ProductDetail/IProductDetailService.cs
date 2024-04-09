using MultiShop.Catalog.Dtos.ProductDetail;

namespace MultiShop.Catalog.Services.ProductDetail;

public interface IProductDetailService
{
    Task<List<ProductDetailResultDto>> GetAllAsync();
    Task<ProductDetailGetByIdDto> GetByIdAsync(string productDetailId);
    Task CreateAsync(ProductDetailCreateDto productDetailCreateDto);
    Task UpdateAsync(ProductDetailUpdateDto productDetailUpdateDto);
    Task DeleteAsync(string productDetailId);
}