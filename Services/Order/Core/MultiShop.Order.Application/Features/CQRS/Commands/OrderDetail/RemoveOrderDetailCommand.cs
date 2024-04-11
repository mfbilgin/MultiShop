namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetail;

public class RemoveOrderDetailCommand(int productOrderDetailId)
{
    public int OrderDetailId { get; set; } = productOrderDetailId;
}