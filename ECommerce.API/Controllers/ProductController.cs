using ECommerce.API.Entities;
using ECommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _repository.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _repository.CreateProduct(product);
            return Ok();
        }

        [HttpGet("findbyproductid/{id}")]
        public async Task<IActionResult> FindProductByProductId(int id)
        {
            return Ok(await _repository.FindByProductId(id));
        }

        [HttpPatch("updateproduct/{id}")]
        public async Task<IActionResult> UpdateProduct(Product product, int id)
        {
            await _repository.UpdateProduct(product, id);
            return Ok();
        }

        [HttpDelete("deleteproduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteProduct(id);
            return Ok();
        }
    }
}
