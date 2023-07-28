using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Entities
{

    [Table("TB_PRODUCT")]
    public class Product : Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
