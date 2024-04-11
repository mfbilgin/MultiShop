using MultiShop.Order.Application.Features.CQRS.Commands.Address;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.Address;

public class UpdateAddressCommandHandler(IRepository<Domain.Entities.Address> repository)
{
    public async Task Handle(UpdateAddressCommand request)
    {
        var address = await repository.GetByIdAsync(request.AddressId);
        address.City = request.City;
        address.District = request.District;
        address.UserId = request.UserId;
        address.Detail = request.Detail;
        await repository.UpdateAsync(address);
    }
}