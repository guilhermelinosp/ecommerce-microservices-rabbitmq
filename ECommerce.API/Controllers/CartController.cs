using ECommerce.API.Entities;
using ECommerce.API.Repositories;
using ECommerce.API.ServicesExternal;
using ECommerce.API.ServicesExternal.Messages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly RabbitMqProducerImp _rabbitMqProducer;

        public CartController(ICartRepository repository, RabbitMqProducerImp rabbitMq, RabbitMqProducerImp rabbitMqProducer, ICouponRepository couponRepository)
        {
            _cartRepository = repository;
            _rabbitMqProducer = rabbitMqProducer;
            _couponRepository = couponRepository;
        }

        [HttpGet("findbyuserid/{id}")]
        public async Task<IActionResult> FindByUserId(int id)
        {
            return Ok(await _cartRepository.FindByUserId(id));
        }

        [HttpPost("createcart/{id}")]
        public async Task<IActionResult> CreateCart(Cart cart)
        {
            await _cartRepository.CreateCart(cart);
            return Ok();
        }

        [HttpPatch("updatecart/{id}")]
        public async Task<IActionResult> UpdateCart(Cart cart)
        {
            await _cartRepository.UpdateCart(cart);
            return Ok();
        }

        [HttpDelete("deletecart/{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _cartRepository.DeleteCart(id);
            return Ok();
        }


        [HttpPost("applycoupon")]
        public async Task<IActionResult> ApplyCoupon(Cart vo)
        {
            await _cartRepository.ApplyCoupon(vo.CartHeader!.UserId, vo.CartHeader!.CouponCode!);
            return Ok();
        }

        [HttpDelete("removecoupon/{id}")]
        public async Task<IActionResult> ApplyCoupon(int id)
        {
            await _cartRepository.RemoveCoupon(id);
            return Ok();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(CheckoutHeader vo)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (vo?.UserId == null) return BadRequest();
            var cart = await _cartRepository.FindByUserId(vo.UserId);
            if (cart == null) return NotFound();
            if (!string.IsNullOrEmpty(vo.CouponCode))
            {
                var coupon = await _couponRepository.GetByCouponCode(vo.CouponCode);
                if (vo.DiscountAmount != coupon.Discount)
                {
                    return StatusCode(412);
                }
            }
            vo.CartDetails = cart.CartDetail!;
            vo.DateTime = DateTime.Now;

            _rabbitMqProducer.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }
    }
}
