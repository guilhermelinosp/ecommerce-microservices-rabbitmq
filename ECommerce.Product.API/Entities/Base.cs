using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Product.API.Entities
{
	public class Base
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	}
}
