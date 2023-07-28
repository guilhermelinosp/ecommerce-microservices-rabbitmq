using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Entities
{

    [Table("TB_CART_HEADER")]
    public class CartHeader : Base
    {
        public int UserId { get; set; }
        public string? CouponCode { get; set; }
    }
}
