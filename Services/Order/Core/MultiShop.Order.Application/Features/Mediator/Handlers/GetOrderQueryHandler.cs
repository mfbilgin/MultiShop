using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.Order;
using MultiShop.Order.Application.Features.Mediator.Results.Order;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.Mediator.Handlers;

public class GetOrderQueryHandler(IRepository<Domain.Entities.Order> repository) : IRequestHandler<GetOrderQuery,List<GetOrderQueryResult>>
{
    public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var orders = await repository.GetAllAsync();
        return orders.Select(order => new GetOrderQueryResult
        {
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            OrderId = order.OrderId,
            UserId = order.UserId
        }).ToList();
    }
}