﻿namespace MultiShop.Order.Domain.Entities;

public sealed class Address : IEntity
{
    public int AddressId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    
}   