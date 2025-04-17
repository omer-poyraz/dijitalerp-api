using Entities.DTOs.ProductDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Product", "Read")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                var users = await _manager.ProductService.GetAllProductAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<ProductDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<ProductDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Product", "Read")]
        public async Task<IActionResult> GetOneProductByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ProductService.GetProductByIdAsync(id, false);
                return Ok(ApiResponse<ProductDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ProductDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Product", "Write")]
        public async Task<IActionResult> CreateOneProductAsync(
            [FromForm] ProductDtoForInsertion productDtoForInsertion
        )
        {
            try
            {
                if (productDtoForInsertion.file != null && productDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(productDtoForInsertion.file, imgId, "Product");
                    productDtoForInsertion.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.ProductService.CreateProductAsync(
                    productDtoForInsertion
                );
                return Ok(ApiResponse<ProductDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ProductDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Product", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromForm] ProductDtoForUpdate productDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.ProductService.UpdateProductAsync(productDtoForUpdate);
                return Ok(ApiResponse<ProductDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ProductDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Product", "Delete")]
        public async Task<IActionResult> DeleteOneProductAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ProductService.DeleteProductAsync(id, false);
                return Ok(ApiResponse<ProductDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ProductDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
