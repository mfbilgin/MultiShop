using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetail;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetail;

public class UpdateOrderDetailCommandHandler(IRepository<Domain.Entities.OrderDetail> repository)
{
    public async Task Handle(UpdateOrderDetailCommand request)
    {
        var orderDetail = await repository.GetByIdAsync(request.OrderDetailId);
        if (orderDetail is not null)
        {
            orderDetail.ProductId = request.ProductId;
            orderDetail.ProductName = request.ProductName;
            orderDetail.ProductAmount = request.ProductAmount;
            orderDetail.ProductPrice = request.ProductPrice;
            orderDetail.ProductTotalPrice = request.ProductAmount * request.ProductPrice;
            orderDetail.OrderId = request.OrderId;
            await repository.UpdateAsync(orderDetail);
        }
    }
}