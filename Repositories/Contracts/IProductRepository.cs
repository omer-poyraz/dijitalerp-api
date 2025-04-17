using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProductAsync(bool? trackChanges);
        Task<Product> GetProductByIdAsync(int id, bool? trackChanges);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(Product product);
    }
}
