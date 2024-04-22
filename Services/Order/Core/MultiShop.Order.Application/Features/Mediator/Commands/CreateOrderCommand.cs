using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands;

public class CreateOrderCommand : IRequest
{
    public string UserId { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}