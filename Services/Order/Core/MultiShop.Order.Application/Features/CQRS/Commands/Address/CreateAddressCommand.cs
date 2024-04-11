namespace MultiShop.Order.Application.Features.CQRS.Commands.Address;

public class CreateAddressCommand
{
    public string UserId { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
}