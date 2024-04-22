using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.Order;

namespace MultiShop.Order.Application.Features.Mediator.Queries.Order;

public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
{
    
}