using MultiShop.Order.Application.Features.CQRS.Results.Address;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.Address;

public class GetAddressesQueryHandler(IRepository<Domain.Entities.Address> repository)
{
    public async Task<List<GetAddressByIdQueryResult>> Handle()
    {
        var addresses = await repository.GetAllAsync();
        return addresses.Select(address => new GetAddressByIdQueryResult()
        {
            AddressId = address.AddressId,
            UserId = address.UserId,
            City = address.City,
            Detail = address.City,
            District = address.District
        }).ToList();
    }
}