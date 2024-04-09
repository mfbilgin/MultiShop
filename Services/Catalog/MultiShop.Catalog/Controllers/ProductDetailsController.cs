using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Services.ProductDetail;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController(IProductDetailService productDetailService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var categories = await productDetailService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var productDetail = await productDetailService.GetByIdAsync(id);
        return Ok(productDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(ProductDetailCreateDto productDetailCreateDto)
    {
        await productDetailService.CreateAsync(productDetailCreateDto);
        return Ok("Product detail created.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await productDetailService.DeleteAsync(id);
        return Ok("Product detail deleted.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(ProductDetailUpdateDto productDetailUpdateDto)
    {
        await productDetailService.UpdateAsync(productDetailUpdateDto);
        return Ok("Product detail updated.");
    }
}