using MultiShop.Order.Application.Features.CQRS.Results.OrderDetail;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetail;

public class GetOrderDetailQueryHandler(IRepository<Domain.Entities.OrderDetail> repository)
{
    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var orderDetails = await repository.GetAllAsync();
        return orderDetails.Select(orderDetail => new GetOrderDetailQueryResult
        {
            OrderId = orderDetail.OrderId,
            ProductId = orderDetail.ProductId,
            ProductAmount = orderDetail.ProductAmount,
            ProductPrice = orderDetail.ProductPrice,
            ProductName = orderDetail.ProductName,
            ProductTotalPrice = orderDetail.ProductTotalPrice,
            OrderDetailId = orderDetail.OrderDetailId
        }).ToList();
    }
}