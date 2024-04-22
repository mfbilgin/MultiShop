using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands;

public class RemoveOrderCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}