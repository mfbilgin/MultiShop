namespace MultiShop.Order.Application.Features.Mediator.Results.Order;

public class GetOrderByIdQueryResult
{
    public int OrderId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}   