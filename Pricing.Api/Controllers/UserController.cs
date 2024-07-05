using Microsoft.AspNetCore.Mvc;
using Pricing.Application.Dtos.User;
using Pricing.Application.Services;

namespace Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserCreateRequests request, [FromServices] UserService service)
        {
            var result = await service.Create(request);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserUpdateRequests request, [FromServices] UserService service)
        { 
            var x = service.Update(request); 
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid id, [FromServices] UserService service)
        {
            var x = service.GetById(id);
            return Ok(x);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] UserService service)
        {
            var x = service.GetAll();
            return Ok(x);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] UserService service) 
        {
            service.Delete(id);
            return Ok();
        }
    }
}
