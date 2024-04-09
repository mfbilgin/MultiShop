using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Services.Category;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var categories = await categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var category = await categoryService.GetByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryCreateDto categoryCreateDto)
    {
        await categoryService.CreateAsync(categoryCreateDto);
        return Ok("Category created.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await categoryService.DeleteAsync(id);
        return Ok("Category deleted.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
    {
        await categoryService.UpdateAsync(categoryUpdateDto);
        return Ok("Category updated.");
    }
}