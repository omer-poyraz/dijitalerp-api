using Entities.DTOs.AssemblyFailureStateDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/AssemblyFailureState")]
    public class AssemblyFailureStateController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssemblyFailureStateController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("AssemblyFailureState", "Read")]
        public async Task<IActionResult> GetAllAssemblyFailureStatesAsync()
        {
            try
            {
                var users = await _manager.AssemblyFailureStateService.GetAllAssemblyFailureStateAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<AssemblyFailureStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<AssemblyFailureStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("AssemblyFailureState", "Read")]
        public async Task<IActionResult> GetOneAssemblyFailureStateByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyFailureStateService.GetAssemblyFailureStateByIdAsync(id, false);
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("AssemblyFailureState", "Write")]
        public async Task<IActionResult> CreateOneAssemblyFailureStateAsync(
            [FromBody] AssemblyFailureStateDtoForInsertion assemblyFailureStateDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.AssemblyFailureStateService.CreateAssemblyFailureStateAsync(
                    assemblyFailureStateDtoForInsertion
                );
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("AssemblyFailureState", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] AssemblyFailureStateDtoForUpdate assemblyFailureStateDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.AssemblyFailureStateService.UpdateAssemblyFailureStateAsync(assemblyFailureStateDtoForUpdate);
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("AssemblyFailureState", "Delete")]
        public async Task<IActionResult> DeleteOneAssemblyFailureStateAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyFailureStateService.DeleteAssemblyFailureStateAsync(id, false);
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
