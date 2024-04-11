using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public interface ICouponService
{
    Task<List<CouponResultDto>> GetAllAsync();
    Task CreateCouponAsync(CouponCreateDto couponCreateDto);
    Task UpdateCouponAsync(CouponUpdateDto couponUpdateDto);
    Task DeleteCouponAsync(int id);
    Task<CouponGetByIdDto?> GetCouponByIdAsync(int id);
}