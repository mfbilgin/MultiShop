using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.Mediator.Handlers;

public class RemoveOrderCommandHandler(IRepository<Domain.Entities.Order> repository) : IRequestHandler<RemoveOrderCommand>
{
    public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id);
        if(order is null) return;
        await repository.DeleteAsync(order);
    }
}