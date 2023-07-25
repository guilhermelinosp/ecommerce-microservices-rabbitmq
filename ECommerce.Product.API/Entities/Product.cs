using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Product.API.Entities
{

	[Table("TB_PRODUCT")]
	public class Product : Base
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
		public decimal Price { get; set; }
		public required string Category { get; set; }
		public int Stock { get; set; }
	}
}
