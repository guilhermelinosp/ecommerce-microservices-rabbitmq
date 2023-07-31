using ECommerce.API.Entities;
using ECommerce.API.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Implementations
{
    public class CouponRepositoryImp : ICouponRepository
    {
        private readonly AppDbContext _context;

        public CouponRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        public Task<Coupon?> GetByCouponCode(string couponCode)
        {
            return _context.Coupons!.FirstOrDefaultAsync(c => c.Code == couponCode);
        }
    }
}
