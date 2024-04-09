using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Services.Product;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var categories = await productService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await productService.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductCreateDto productCreateDto)
    {
        await productService.CreateAsync(productCreateDto);
        return Ok("Product created.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await productService.DeleteAsync(id);
        return Ok("Product deleted.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto)
    {
        await productService.UpdateAsync(productUpdateDto);
        return Ok("Product updated.");
    }
}