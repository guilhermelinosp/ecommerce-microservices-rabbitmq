namespace ECommerce.API.DTOs
{
    public class CartDto
    {
        public CartHeaderDto? CartHeader { get; set; }
        public IEnumerable<CartDetailDto>? CartDetail { get; set; }
    }
}
