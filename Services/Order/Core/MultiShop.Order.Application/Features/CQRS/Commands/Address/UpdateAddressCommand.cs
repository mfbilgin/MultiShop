﻿namespace MultiShop.Order.Application.Features.CQRS.Commands.Address;

public class UpdateAddressCommand
{
    public int AddressId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty; 
}