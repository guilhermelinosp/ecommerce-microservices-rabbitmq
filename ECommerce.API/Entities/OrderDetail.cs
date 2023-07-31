using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Entities
{
    [Table("TB_ORDER_DETAIL")]
    public class OrderDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public virtual required OrderHeader OrderHeader { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}
