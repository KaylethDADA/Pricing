using Microsoft.AspNetCore.Mvc;
using Pricing.Application.Dtos.Authentications;
using Pricing.Application.Services;

namespace Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, [FromServices] AuthService service)
        {
            var x = await service.Login(request);
            return Ok(x);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterRequest request, [FromServices] AuthService service)
        {
            await service.Registration(request);
            return Ok();
        }
    }
}
