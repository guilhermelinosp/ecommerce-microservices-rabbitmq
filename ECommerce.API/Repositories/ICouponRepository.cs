using ECommerce.API.Entities;

namespace ECommerce.API.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon?> GetByCouponCode(string couponCode);
    }
}
