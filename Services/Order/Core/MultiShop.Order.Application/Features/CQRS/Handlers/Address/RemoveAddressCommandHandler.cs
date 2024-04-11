using MultiShop.Order.Application.Features.CQRS.Commands.Address;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.Address;

public class RemoveAddressCommandHandler(IRepository<Domain.Entities.Address> repository)
{
    public async Task Handle(RemoveAddressCommand request)
    {
        var address = await repository.GetByIdAsync(request.AddressId);
        await repository.DeleteAsync(address);
    }
}