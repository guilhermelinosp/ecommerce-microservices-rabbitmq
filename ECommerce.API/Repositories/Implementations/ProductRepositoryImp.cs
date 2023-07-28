using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.API.Entities;
using ECommerce.API.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Implementations
{
    public class ProductRepositoryImp : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepositoryImp(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            return await _context.Products!.ToListAsync();
        }

        public async Task<Product?> FindByProductId(int id)
        {
            return await _context.Products!.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProduct(ProductDto product)
        {
            await _context.Products!.AddAsync(_mapper.Map<Product>(product));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductDto product, int id)
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
