using ECommerce.API.Entities;

namespace ECommerce.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();
        Task<Product?> FindByProductId(int productId);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product, int productId);
        Task DeleteProduct(int productId);
    }
}
