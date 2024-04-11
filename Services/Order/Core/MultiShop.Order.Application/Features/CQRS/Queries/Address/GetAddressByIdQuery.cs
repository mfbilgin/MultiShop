namespace MultiShop.Order.Application.Features.CQRS.Queries.Address;

public class GetAddressByIdQuery(int addressId)
{
    public int AddressId { get; set; } = addressId;
}