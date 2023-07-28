using AutoMapper;
using ECommerce.API.Entities;
using ECommerce.API.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Implementations
{
    public class CouponRepositoryImp : ICouponRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CouponRepositoryImp(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Coupon?> GetByCouponCode(string couponCode)
        {
            return _context.Coupons!.FirstOrDefaultAsync(c => c.Code == couponCode);
        }
    }
}
