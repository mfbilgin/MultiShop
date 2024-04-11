using MultiShop.Order.Application.Features.CQRS.Queries.Address;
using MultiShop.Order.Application.Features.CQRS.Results.Address;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.Address;

public class GetAddressByIdQueryHandler(IRepository<Domain.Entities.Address> repository)
{
    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request)
    {
        var address = await repository.GetByIdAsync(request.AddressId);
        return new GetAddressByIdQueryResult()
        {
            AddressId = address.AddressId,
            UserId = address.UserId,
            City = address.City,
            Detail = address.City,
            District = address.District
        };
    }
}