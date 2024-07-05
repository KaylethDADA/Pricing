using Microsoft.AspNetCore.Mvc;
using Pricing.Api.WebModels;

namespace Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingController : ControllerBase
    {
        [HttpGet("GetInfo")]
        public IActionResult GetInfo()
        {
            var res = new WebServerResponse();

            return Ok(DateTime.UtcNow);
        }
    }
}