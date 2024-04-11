namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetail;

public class GetOrderDetailByIdQuery(int orderId)
{
    public int OrderId { get; set; } = orderId;
}
