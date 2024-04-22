using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.Order;

namespace MultiShop.Order.Application.Features.Mediator.Queries.Order;

public class GetOrderByIdQuery(int id) : IRequest<GetOrderByIdQueryResult?>
{
    public int Id { get; set; } = id; 
}