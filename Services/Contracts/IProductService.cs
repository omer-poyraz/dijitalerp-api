using Entities.DTOs.ProductDto;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync(bool? trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool? trackChanges);
        Task<ProductDto> CreateProductAsync(ProductDtoForInsertion productDtoForInsertion);
        Task<ProductDto> UpdateProductAsync(ProductDtoForUpdate productDtoForUpdate);
        Task<ProductDto> DeleteProductAsync(int id, bool? trackChanges);
    }
}
