namespace MultiShop.Discount.Entities;

public sealed class Coupon
{
    public int CouponId { get; set; }
    public string CouponCode { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}