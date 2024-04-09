using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Services.ProductImage;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController(IProductImageService productImageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        var categories = await productImageService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var productImage = await productImageService.GetByIdAsync(id);
        return Ok(productImage);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage(ProductImageCreateDto productImageCreateDto)
    {
        await productImageService.CreateAsync(productImageCreateDto);
        return Ok("Product Image created.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await productImageService.DeleteAsync(id);
        return Ok("Product Image deleted.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(ProductImageUpdateDto productImageUpdateDto)
    {
        await productImageService.UpdateAsync(productImageUpdateDto);
        return Ok("Product Image updated.");
    }
}