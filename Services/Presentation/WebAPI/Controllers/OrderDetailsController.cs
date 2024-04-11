using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetail;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetail;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetail;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(
    GetOrderDetailQueryHandler getAllHandler,
    GetOrderDetailByIdQueryHandler getByIdHandler,
    CreateOrderDetailCommandHandler createHandler,
    UpdateOrderDetailCommandHandler updateHandler,
    RemoveOrderDetailCommandHandler removeHandler
    ) :ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> OrderDetailList()
    {
        var result = await getAllHandler.Handle();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> OrderDetailById(int id)
    {
        var result = await getByIdHandler.Handle(new GetOrderDetailByIdQuery(id));
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
    { 
        await createHandler.Handle(command);
        return Ok("OrderDetail created successfully");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
    {
        await updateHandler.Handle(command);
        return Ok("OrderDetail updated successfully");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveOrderDetail(int id)
    {
        await removeHandler.Handle(new RemoveOrderDetailCommand(id));
        return Ok("OrderDetail removed successfully");
    }
}