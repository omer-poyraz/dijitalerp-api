using AutoMapper;
using Entities.DTOs.ProductDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(
            ProductDtoForInsertion productDtoForInsertion
        )
        {
            var product = _mapper.Map<Entities.Models.Product>(productDtoForInsertion);
            _manager.ProductRepository.CreateProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> DeleteProductAsync(int id, bool? trackChanges)
        {
            var product = await _manager.ProductRepository.GetProductByIdAsync(id, trackChanges);
            _manager.ProductRepository.DeleteProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync(bool? trackChanges)
        {
            var product = await _manager.ProductRepository.GetAllProductAsync(trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool? trackChanges)
        {
            var product = await _manager.ProductRepository.GetProductByIdAsync(id, trackChanges);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(ProductDtoForUpdate productDtoForUpdate)
        {
            var product = await _manager.ProductRepository.GetProductByIdAsync(productDtoForUpdate.ID, productDtoForUpdate.TrackChanges);
            var existingFiles = product.Files?.ToList() ?? new List<string>();
            var newFiles = productDtoForUpdate.Files;
            productDtoForUpdate.Files = null;
            _mapper.Map(productDtoForUpdate, product);
            if (newFiles != null && newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    existingFiles.Add(file);
                }
            }
            product.Files = existingFiles;
            _manager.ProductRepository.UpdateProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
