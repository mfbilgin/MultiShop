using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands;
using MultiShop.Order.Application.Features.Mediator.Queries.Order;

namespace WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> OrderList()
    {
        var orders = await mediator.Send(new GetOrderQuery());
        return Ok(orders);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await mediator.Send(new GetOrderByIdQuery(id));
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand request)
    {
        await mediator.Send(request);
        return Ok("Order created successfully");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveOrder(RemoveOrderCommand request)
    {
        await mediator.Send(request);
        return Ok("Order removed successfully");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder(UpdateOrderCommand request)
    {
        await mediator.Send(request);
        return Ok("Order updated successfully");
    }
}