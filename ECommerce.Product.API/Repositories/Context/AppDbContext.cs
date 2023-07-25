using Microsoft.EntityFrameworkCore;

namespace ECommerce.Product.API.Repositories.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Entities.Product>? Products { get; set; }
	}
}
