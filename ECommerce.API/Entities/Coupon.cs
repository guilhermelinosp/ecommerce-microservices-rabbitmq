using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Entities
{
    [Table("TB_COUPON")]
    public class Coupon : Base
    {
        public string? Code { get; set; }
        public decimal Discount { get; set; }
    }
}
