using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public sealed class CouponManager(DapperContext context) : ICouponService
{
    public async Task<List<CouponResultDto>> GetAllAsync()
    {
        const string query = "SELECT * FROM Coupons";
        using var connection = context.CreateConnection();
        var coupons = await connection.QueryAsync<CouponResultDto>(query);
        return coupons.ToList();
    }

    public async Task CreateCouponAsync(CouponCreateDto couponCreateDto)
    {
        const string query = "INSERT INTO (CouponCode, Rate, IsActive, ValidDate) VALUES (@CouponCode, @Rate, @IsActive, @ValidDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponCode", couponCreateDto.CouponCode);
        parameters.Add("@Rate", couponCreateDto.Rate);
        parameters.Add("@IsActive", couponCreateDto.IsActive);
        parameters.Add("@ValidDate", couponCreateDto.ValidDate);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task UpdateCouponAsync(CouponUpdateDto couponUpdateDto)
    {
        const string query = "UPDATE Coupons SET CouponCode = @CouponCode, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponId", couponUpdateDto.CouponId);
        parameters.Add("@CouponCode", couponUpdateDto.CouponCode);
        parameters.Add("@Rate", couponUpdateDto.Rate);
        parameters.Add("@IsActive", couponUpdateDto.IsActive);
        parameters.Add("@ValidDate", couponUpdateDto.ValidDate);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteCouponAsync(int id)
    {
        const string query = "DELETE FROM Coupons WHERE CouponId = @CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponId", id);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query,parameters);
    }

    public async Task<CouponGetByIdDto?> GetCouponByIdAsync(int id)
    {
        const string query = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
        var parameters = new DynamicParameters();
        parameters.Add("@CouponId", id);
        using var connection = context.CreateConnection();
        var coupon = await connection.QueryFirstOrDefaultAsync<CouponGetByIdDto>(query, parameters);
        return coupon;
    }
}