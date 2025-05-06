using Entities.DTOs.AssemblyQualityDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/AssemblyQuality")]
    public class AssemblyQualityController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssemblyQualityController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("AssemblyQuality", "Read")]
        public async Task<IActionResult> GetAllAssemblyQualityAsync()
        {
            try
            {
                var users = await _manager.AssemblyQualityService.GetAllAssemblyQualityAsync(false);
                return Ok(ApiResponse<IEnumerable<AssemblyQualityDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<AssemblyQualityDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("GetAllByFailure/{id:int}")]
        [AuthorizePermission("AssemblyQuality", "Read")]
        public async Task<IActionResult> GetAllAssemblyQualityByFailureAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.AssemblyQualityService.GetAllAssemblyQualityByFailureAsync(id, false);
                return Ok(ApiResponse<IEnumerable<AssemblyQualityDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<AssemblyQualityDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("AssemblyQuality", "Read")]
        public async Task<IActionResult> GetOneAssemblyQualityByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyQualityService.GetAssemblyQualityByIdAsync(id, false);
                return Ok(ApiResponse<AssemblyQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyQualityDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("AssemblyQuality", "Write")]
        public async Task<IActionResult> CreateOneAssemblyQualityAsync([FromBody] AssemblyQualityDtoForInsertion assemblyQualityDtoForInsertion)
        {
            try
            {
                var user = await _manager.AssemblyQualityService.CreateAssemblyQualityAsync(assemblyQualityDtoForInsertion);
                return Ok(ApiResponse<AssemblyQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyQualityDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("AssemblyQuality", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromBody] AssemblyQualityDtoForUpdate assemblyQualityDtoForUpdate)
        {
            try
            {
                var user = await _manager.AssemblyQualityService.UpdateAssemblyQualityAsync(assemblyQualityDtoForUpdate);
                return Ok(ApiResponse<AssemblyQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyQualityDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("AssemblyQuality", "Delete")]
        public async Task<IActionResult> DeleteOneAssemblyQualityAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyQualityService.DeleteAssemblyQualityAsync(id, false);
                return Ok(ApiResponse<AssemblyQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyQualityDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
