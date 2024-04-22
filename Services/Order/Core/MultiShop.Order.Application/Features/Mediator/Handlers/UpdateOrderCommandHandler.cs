using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.Mediator.Handlers;

public class UpdateOrderCommandHandler(IRepository<Domain.Entities.Order> repository) : IRequestHandler<UpdateOrderCommand>
{
    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.OrderId);
        if (order is null) return;
        order.OrderDate = request.OrderDate;
        order.UserId = request.UserId;
        order.TotalPrice = request.TotalPrice;
        await repository.UpdateAsync(order);
    }
}