using Microsoft.AspNetCore.Mvc;
using Pricing.Application.Dtos.Category;
using Pricing.Application.Services;

namespace Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateRequests request, [FromServices] ProductCategoryService service)
        {
            var x = await service.Create(request);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CategoryUpdateRequests request, [FromServices] ProductCategoryService service)
        {
            var x = service.Update(request);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid id, [FromServices] ProductCategoryService service)
        {
            var x = service.GetById(id);
            return Ok(x);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] ProductCategoryService service)
        {
            var x = service.GetAll();
            return Ok(x);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] ProductCategoryService service)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
