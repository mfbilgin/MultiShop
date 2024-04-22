using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> productUserManager)
        {
            _userManager = productUserManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var user = new ApplicationUser
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                PhoneNumber = userRegisterDto.PhoneNumber,
                LastName = userRegisterDto.LastName
            };
            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("User created successfully");
            }
            return BadRequest(result.Errors);
        }
    }
}