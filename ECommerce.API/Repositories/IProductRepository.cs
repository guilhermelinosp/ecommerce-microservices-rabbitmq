using ECommerce.API.DTOs;
using ECommerce.API.Entities;

namespace ECommerce.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();
        Task<Product?> FindByProductId(int productId);
        Task CreateProduct(ProductDto product);
        Task UpdateProduct(ProductDto product, int productId);
        Task DeleteProduct(int productId);
    }
}
