using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetail;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetail;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetail;

public class GetOrderDetailByIdQueryHandler(IRepository<Domain.Entities.OrderDetail> repository)
{
    public async Task<GetOrderDetailByIdQueryResult?> Handle(GetOrderDetailByIdQuery request)
    {
        var orderDetail = await repository.GetByIdAsync(request.OrderId);
        if (orderDetail != null)
            return new GetOrderDetailByIdQueryResult
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                ProductAmount = orderDetail.ProductAmount,
                ProductPrice = orderDetail.ProductPrice,
                ProductName = orderDetail.ProductName,
                ProductTotalPrice = orderDetail.ProductTotalPrice,
                OrderDetailId = orderDetail.OrderDetailId
            };
        return null;
    }
}