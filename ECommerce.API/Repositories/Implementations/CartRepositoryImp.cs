using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.API.Entities;
using ECommerce.API.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Implementations
{
    public class CartRepositoryImp : ICartRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CartRepositoryImp(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CleanCart(int userId)
        {
            var cartHeader = await _context.CartHeaders!.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cartHeader != null)
            {
                _context.CartDetails!.RemoveRange(_context.CartDetails.Where(c => c.CartHeaderId == cartHeader.Id));
                _context.CartHeaders!.Remove(cartHeader);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateCart(CartDto cart)
        {
            var mapper = _mapper.Map<Cart>(cart);
            var cartDatail = mapper.CartDetail!.FirstOrDefault()!;
            var cartHeader = mapper.CartHeader!;

            var product = await _context.Products!.FirstOrDefaultAsync(p => p.Id == cartDatail.ProductId);
            if (product == null)
            {
                _context.Products!.Add(cartDatail.Product!);
                await _context.SaveChangesAsync();
            }

            var cartHeaderExist = await _context.CartHeaders!.FirstOrDefaultAsync(c => c.UserId == cartHeader.UserId);
            if (cartHeaderExist == null)
            {
                _context.CartHeaders!.Add(cartHeader);
                await _context.SaveChangesAsync();
                cartDatail.CartHeaderId = cartHeader.Id;
                cartDatail.Product = null;
                _context.CartDetails!.Add(cartDatail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CartDto> FindByUserId(int userId)
        {
            var cart = new Cart()
            {
                CartHeader = await _context.CartHeaders!.FirstOrDefaultAsync(c => c.UserId == userId),
            };

            cart.CartDetail = _context.CartDetails!
                .Where(c => c.CartHeaderId == cart.CartHeader!.Id)
                .Include(c => c.Product);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task UpdateCart(CartDto cart)
        {
            var mapper = _mapper.Map<Cart>(cart);
            var cartDatail = mapper.CartDetail!.FirstOrDefault()!;
            var cartHeader = mapper.CartHeader!;

            var cartHeaderExist = await _context.CartHeaders!.FirstOrDefaultAsync(c => c.UserId == cartHeader.UserId);
            if (cartHeaderExist != null)
            {
                var cartDetail = await _context.CartDetails!.FirstOrDefaultAsync(p => p.ProductId == cartDatail.ProductId && p.CartHeaderId == cartHeader.Id);
                if (cartDetail == null)
                {
                    cartDatail.CartHeaderId = cartHeader.Id;
                    cartDatail.Product = null;
                    _context.CartDetails!.Add(cartDatail);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    cartDatail.Product = null;
                    cartDatail.Count += cartDetail.Count;
                    cartDatail.Id = cartDetail.Id;
                    cartDatail.CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetails!.Update(cartDatail);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteCart(int userId)
        {
            var cartDetail = await _context.CartDetails!.FirstOrDefaultAsync(c => c.Id == userId);

            if (cartDetail != null)
            {
                _context.CartDetails!.Remove(cartDetail);

                if (_context.CartDetails!.Count(c => c.CartHeaderId == cartDetail.CartHeaderId) == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeaders!.FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);

                    if (cartHeaderToRemove != null) _context.CartHeaders!.Remove(cartHeaderToRemove);
                }

                await _context.SaveChangesAsync();
            }
        }

        public Task ApplyCoupon(int userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCoupon(int userId)
        {
            throw new NotImplementedException();
        }
    }
}