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
                var assemblyFailureStates = await _manager.AssemblyFailureStateService.GetAllAssemblyFailureStateAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<AssemblyFailureStateDto>>.CreateSuccess(_httpContextAccessor, assemblyFailureStates, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<AssemblyFailureStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByManual/{id:int}")]
        [AuthorizePermission("AssemblyFailureState", "Read")]
        public async Task<IActionResult> GetAllAssemblyFailureStatesByManualAsync([FromRoute] int id)
        {
            try
            {
                var assemblyFailureStates = await _manager.AssemblyFailureStateService.GetAllAssemblyFailureStateByManualAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<AssemblyFailureStateDto>>.CreateSuccess(_httpContextAccessor, assemblyFailureStates, "Success.Listed")
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
                var assemblyFailureState = await _manager.AssemblyFailureStateService.GetAssemblyFailureStateByIdAsync(id, false);
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, assemblyFailureState, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("GetQualityOfficer/{userId}")]
        [AuthorizePermission("AssemblyFailureState", "Read")]
        public async Task<IActionResult> GetOneAssemblyFailureStateByQualityOfficerAsync([FromRoute] string userId)
        {
            try
            {
                var assemblyFailureState = await _manager.AssemblyFailureStateService.GetAllAssemblyFailureStateByQualityOfficerAsync(userId, false);
                return Ok(ApiResponse<IEnumerable<AssemblyFailureStateDto>>.CreateSuccess(_httpContextAccessor, assemblyFailureState, "Success.Retrieved"));
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
                var assemblyFailureState = await _manager.AssemblyFailureStateService.CreateAssemblyFailureStateAsync(
                    assemblyFailureStateDtoForInsertion
                );
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, assemblyFailureState, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("AssemblyFailureState", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromBody] AssemblyFailureStateDtoForUpdate assemblyFailureStateDtoForUpdate)
        {
            try
            {
                var assemblyFailureState = await _manager.AssemblyFailureStateService.UpdateAssemblyFailureStateAsync(assemblyFailureStateDtoForUpdate);
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, assemblyFailureState, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("QualityDescription")]
        [AuthorizePermission("AssemblyQuality", "Write")]
        public async Task<IActionResult> UpdateQualityDescriptonAsync([FromBody] AssemblyFailureStateDtoForQuality assemblyFailureStateDtoForQuality)
        {
            try
            {
                var assemblyFailureState = await _manager.AssemblyFailureStateService.UpdateAssemblyFailureByQualityStateAsync(assemblyFailureStateDtoForQuality);
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, assemblyFailureState, "Success.Updated"));
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
                var assemblyFailureState = await _manager.AssemblyFailureStateService.DeleteAssemblyFailureStateAsync(id, false);
                return Ok(ApiResponse<AssemblyFailureStateDto>.CreateSuccess(_httpContextAccessor, assemblyFailureState, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
