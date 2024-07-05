using Microsoft.AspNetCore.Mvc;
using Pricing.Application.Dtos.Product;
using Pricing.Application.Interfaces;
using Pricing.Application.Services;

namespace Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequests request, [FromServices] ProductService service)
        {
            var x =  await service.Create(request);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ProductUpdateRequests request, [FromServices] ProductService service)
        {
            var x = service.Update(request);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid id, [FromServices] ProductService service)
        {
            var x = service.GetById(id);
            return Ok(x);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] ProductService service)
        {
            var x = service.GetAll();
            return Ok(x);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] ProductService service)
        {
            service.Delete(id);
            return Ok();
        }

        [HttpPost("RegisterProduct")]
        public async Task<IActionResult> DistributeProduct(Guid productId, Guid shopId)
        {
            try
            {
                await _productRepository.DistributeProductToShopAsync(productId, shopId);
                return Ok("Product register successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
