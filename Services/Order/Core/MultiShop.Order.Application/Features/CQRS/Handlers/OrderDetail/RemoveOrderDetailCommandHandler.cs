using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetail;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetail;

public class RemoveOrderDetailCommandHandler(IRepository<Domain.Entities.OrderDetail> repository)
{
    public async Task Handle(RemoveOrderDetailCommand request)
    {
        var orderDetail = await repository.GetByIdAsync(request.OrderDetailId);
        if (orderDetail is not null)
            await repository.DeleteAsync(orderDetail);
    }
}