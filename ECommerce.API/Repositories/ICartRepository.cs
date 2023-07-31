using ECommerce.API.Entities;

namespace ECommerce.API.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> FindByUserId(int userId);
        Task CreateCart(Cart cart);
        Task UpdateCart(Cart cart);
        Task DeleteCart(int userId);
        Task ApplyCoupon(int userId, string couponCode);
        Task RemoveCoupon(int userId);
        Task CleanCart(int userId);
    }
}
