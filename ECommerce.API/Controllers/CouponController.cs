using ECommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("findbycouponcode/{code}")]
        public async Task<IActionResult> GetByCouponCode(string code)
        {
            return Ok(await _repository.GetByCouponCode(code));
        }
    }
}
