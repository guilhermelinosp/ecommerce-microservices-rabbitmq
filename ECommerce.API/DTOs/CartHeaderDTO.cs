namespace ECommerce.API.DTOs
{
    public class CartHeaderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? CouponCode { get; set; }
    }
}
