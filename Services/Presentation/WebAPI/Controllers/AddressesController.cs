using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.Address;
using MultiShop.Order.Application.Features.CQRS.Handlers.Address;
using MultiShop.Order.Application.Features.CQRS.Queries.Address;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController(GetAddressesQueryHandler getAllHandler,GetAddressByIdQueryHandler getByIdHandler,CreateAddressCommandHandler createHandler,UpdateAddressCommandHandler updateHandler,RemoveAddressCommandHandler removeHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> AddressList()
    {
        var result = await getAllHandler.Handle();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> AddressById(int id)
    {
        var result = await getByIdHandler.Handle(new GetAddressByIdQuery(id));
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
    { 
        await createHandler.Handle(command);
        return Ok("Address created successfully");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
    {
        await updateHandler.Handle(command);
        return Ok("Address updated successfully");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAddress(int id)
    {
        await removeHandler.Handle(new RemoveAddressCommand(id));
        return Ok("Address removed successfully");
    }
}