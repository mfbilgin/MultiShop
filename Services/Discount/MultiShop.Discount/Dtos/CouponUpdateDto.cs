﻿namespace MultiShop.Discount.Dtos;

public sealed class CouponUpdateDto
{
    public int CouponId { get; set; }
    public string CouponCode { get; set; } = string.Empty;
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}