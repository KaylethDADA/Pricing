using Microsoft.AspNetCore.Mvc;
using Pricing.Application.Dtos.Shop;
using Pricing.Application.Services;

namespace Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ShopCreateRequests request, [FromServices] ShopService service)
        {
            var x = await service.Create(request);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ShopUpdateRequests request, [FromServices] ShopService service)
        {
            var x = service.Update(request);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid id, [FromServices] ShopService service)
        {
            var x = service.GetById(id);
            return Ok(x);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] ShopService service)
        {
            var x = service.GetAll();
            return Ok(x);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] ShopService service)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
