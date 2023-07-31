using ECommerce.API.Entities;
using ECommerce.API.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Implementations
{
    public class ProductRepositoryImp : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepositoryImp(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            return await _context.Products!.ToListAsync();
        }

        public async Task<Product?> FindByProductId(int id)
        {
            return await _context.Products!.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products!.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product, int id)
        {
            var findProduct = await _context.Products!.FirstOrDefaultAsync(p => p.Id == id);

            if (findProduct != null)
            {
                findProduct.Name = product.Name ?? findProduct.Name;
                findProduct.Description = product.Description ?? findProduct.Description;
                findProduct.Price = product.Price ?? findProduct.Price;
                findProduct.Category = product.Category ?? findProduct.Category;

                _context.Products!.Update(findProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var findProduct = await _context.Products!.FirstOrDefaultAsync(p => p.Id == id);

            if (findProduct != null)
            {
                _context.Products!.Remove(findProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
