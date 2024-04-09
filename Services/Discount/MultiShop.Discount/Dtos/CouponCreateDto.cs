namespace MultiShop.Discount.Dtos;

public sealed class CouponCreateDto
{
    public string CouponCode { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}