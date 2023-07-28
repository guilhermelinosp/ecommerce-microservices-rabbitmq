using ECommerce.API.DTOs;

namespace ECommerce.API.Repositories
{
    public interface ICartRepository
    {
        Task<CartDto> FindByUserId(int userId);
        Task CreateCart(CartDto cart);
        Task UpdateCart(CartDto cart);
        Task DeleteCart(int userId);
        Task ApplyCoupon(int userId, string couponCode);
        Task RemoveCoupon(int userId);
        Task CleanCart(int userId);
    }
}
