using Entities.DTOs.AssemblySuccessStateDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/AssemblySuccessState")]
    public class AssemblySuccessStateController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssemblySuccessStateController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("AssemblySuccessState", "Read")]
        public async Task<IActionResult> GetAllAssemblySuccessStatesAsync()
        {
            try
            {
                var users = await _manager.AssemblySuccessStateService.GetAllAssemblySuccessStateAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<AssemblySuccessStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<AssemblySuccessStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByManual/{id:int}")]
        [AuthorizePermission("AssemblySuccessState", "Read")]
        public async Task<IActionResult> GetAllAssemblySuccessStatesAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.AssemblySuccessStateService.GetAllAssemblySuccessStateByManualAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<AssemblySuccessStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<AssemblySuccessStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("AssemblySuccessState", "Read")]
        public async Task<IActionResult> GetOneAssemblySuccessStateByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblySuccessStateService.GetAssemblySuccessStateByIdAsync(id, false);
                return Ok(ApiResponse<AssemblySuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblySuccessStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("AssemblySuccessState", "Write")]
        public async Task<IActionResult> CreateOneAssemblySuccessStateAsync(
            [FromBody] AssemblySuccessStateDtoForInsertion assemblySuccessStateDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.AssemblySuccessStateService.CreateAssemblySuccessStateAsync(
                    assemblySuccessStateDtoForInsertion
                );
                return Ok(ApiResponse<AssemblySuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblySuccessStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("AssemblySuccessState", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] AssemblySuccessStateDtoForUpdate assemblySuccessStateDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.AssemblySuccessStateService.UpdateAssemblySuccessStateAsync(assemblySuccessStateDtoForUpdate);
                return Ok(ApiResponse<AssemblySuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblySuccessStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("AssemblySuccessState", "Delete")]
        public async Task<IActionResult> DeleteOneAssemblySuccessStateAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblySuccessStateService.DeleteAssemblySuccessStateAsync(id, false);
                return Ok(ApiResponse<AssemblySuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblySuccessStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
