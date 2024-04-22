using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands;

public class UpdateOrderCommand : IRequest
{
    public int OrderId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}