namespace MultiShop.Order.Application.Features.CQRS.Commands.Address;

public class RemoveAddressCommand(int addressId)
{
    public int AddressId { get; set; } = addressId;
}