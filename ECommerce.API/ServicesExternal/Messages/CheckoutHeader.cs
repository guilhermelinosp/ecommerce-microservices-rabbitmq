using ECommerce.API.Entities;

namespace ECommerce.API.ServicesExternal.Messages
{
    public class CheckoutHeader
    {
        public int Id { get; set; }
        public DateTime MessageCreated { get; set; }
        public int UserId { get; set; }
        public required string CouponCode { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateTime { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string CardNumber { get; set; }
        public required string CVV { get; set; }
        public required string ExpiryMothYear { get; set; }
        public int CartTotalItens { get; set; }
        public required IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
