using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context) { }

        public Product CreateProduct(Product product)
        {
            Create(product);
            return product;
        }

        public Product DeleteProduct(Product product)
        {
            Delete(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public Product UpdateProduct(Product product)
        {
            Update(product);
            return product;
        }
    }
}
