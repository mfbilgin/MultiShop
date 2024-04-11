﻿namespace MultiShop.Order.Application.Features.CQRS.Results.OrderDetail;

public class GetOrderDetailByIdQueryResult
{
    public int OrderDetailId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int OrderId { get; set; }
}