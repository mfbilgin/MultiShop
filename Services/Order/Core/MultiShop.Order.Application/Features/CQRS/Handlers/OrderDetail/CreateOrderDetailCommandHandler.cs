using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetail;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetail;

public class CreateOrderDetailCommandHandler(IRepository<Domain.Entities.OrderDetail> repository)
{
    public async Task Handle(CreateOrderDetailCommand request)
    {
        var orderDetail = new Domain.Entities.OrderDetail
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            ProductAmount = request.ProductAmount,
            ProductPrice = request.ProductPrice,
            ProductName = request.ProductName,
            ProductTotalPrice = request.ProductPrice * request.ProductAmount
        };
        await repository.CreateAsync(orderDetail);
    }
}