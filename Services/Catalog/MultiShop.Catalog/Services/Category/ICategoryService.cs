using MultiShop.Catalog.Dtos.Category;

namespace MultiShop.Catalog.Services.Category;

public interface ICategoryService
{
    Task<List<CategoryResultDto>> GetAllAsync();
    Task<CategoryGetByIdDto> GetByIdAsync(string categoryId);
    Task CreateAsync(CategoryCreateDto categoryCreateDto);
    Task UpdateAsync(CategoryUpdateDto categoryUpdateDto);
    Task DeleteAsync(string categoryId);
}