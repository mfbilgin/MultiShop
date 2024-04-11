using MultiShop.Order.Application.Features.CQRS.Commands.Address;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.Address;

public class CreateAddressCommandHandler(IRepository<Domain.Entities.Address> repository)
{
    public async Task Handle(CreateAddressCommand request)
    {
        var address = new Domain.Entities.Address
        {
            City = request.City,
            Detail = request.Detail,
            District = request.District,
            UserId = request.UserId
        };
        await repository.AddAsync(address);
    }
}