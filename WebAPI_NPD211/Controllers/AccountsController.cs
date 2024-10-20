using Core.Interfaces;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_NPD211.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountsService accountsService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await accountsService.Register(model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            await accountsService.Login(model);
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountsService.Logout();
            return Ok();
        }
    }
}
