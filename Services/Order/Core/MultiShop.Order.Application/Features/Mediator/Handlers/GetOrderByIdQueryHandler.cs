using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.Order;
using MultiShop.Order.Application.Features.Mediator.Results.Order;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.Mediator.Handlers;

public class GetOrderByIdQueryHandler(IRepository<Domain.Entities.Order> repository) : IRequestHandler<GetOrderByIdQuery,GetOrderByIdQueryResult?>
{
    public async Task<GetOrderByIdQueryResult?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id);
        if (order is null) return null;
        return new GetOrderByIdQueryResult
        {
            OrderId = order.OrderId,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice
        };
    }
}