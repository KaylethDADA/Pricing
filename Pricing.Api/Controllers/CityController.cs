using Microsoft.AspNetCore.Mvc;
using Pricing.Application.Dtos.City;
using Pricing.Application.Services;

namespace Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CityCreateRequests request, [FromServices] CityService service)
        {
            var x = await service.Create(request);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CityUpdateRequests request, [FromServices] CityService service)
        {
            var x = service.Update(request);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid id, [FromServices] CityService service)
        {
            var x = service.GetById(id);
            return Ok(x);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] CityService service)
        {
            var x = service.GetAll();
            return Ok(x);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] CityService service)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
