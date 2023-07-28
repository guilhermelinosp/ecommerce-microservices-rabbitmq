using ECommerce.API.DTOs;
using ECommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("findbyuserid/{id}")]
        public async Task<IActionResult> FindByUserId(int id)
        {
            return Ok(await _repository.FindByUserId(id));
        }

        [HttpPost("createcart/{id}")]
        public async Task<IActionResult> CreateCart(CartDto cart)
        {
            await _repository.CreateCart(cart);
            return Ok();
        }

        [HttpPatch("updatecart/{id}")]
        public async Task<IActionResult> UpdateCart(CartDto cart)
        {
            await _repository.UpdateCart(cart);
            return Ok();
        }

        [HttpDelete("deletecart/{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _repository.DeleteCart(id);
            return Ok();
        }
    }
}
