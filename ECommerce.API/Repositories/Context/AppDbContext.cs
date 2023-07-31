using ECommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.DetectChanges();
            Database.SetCommandTimeout(3000);
            Database.EnsureCreated();
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<CartHeader>? CartHeaders { get; set; }
        public DbSet<CartDetail>? CartDetails { get; set; }
        public DbSet<Coupon>? Coupons { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<OrderHeader>? OrderHeaders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }
    }
}
