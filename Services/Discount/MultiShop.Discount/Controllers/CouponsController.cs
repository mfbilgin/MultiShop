using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponsController(ICouponService couponService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CouponList()
    {
        var coupons = await couponService.GetAllAsync();
        return Ok(coupons);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCouponAsync(CouponCreateDto couponCreateDto)
    {
        await couponService.CreateCouponAsync(couponCreateDto);
        return Ok("Coupon created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCouponAsync(CouponUpdateDto couponUpdateDto)
    {
        await couponService.UpdateCouponAsync(couponUpdateDto);
        return Ok("Coupon updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCouponAsync(int id)
    {
        await couponService.DeleteCouponAsync(id);
        return Ok("Coupon deleted successfully.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCouponByIdAsync(int id)
    {
        var coupon = await couponService.GetCouponByIdAsync(id);
        return Ok(coupon);
    }
    
}