using Entities.DTOs.CMMFailureStateDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/CMMFailureState")]
    public class CMMFailureStateController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CMMFailureStateController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("CMMFailureState", "Read")]
        public async Task<IActionResult> GetAllCMMFailureStatesAsync()
        {
            try
            {
                var cmmFailureStates = await _manager.CMMFailureStateService.GetAllCMMFailureStateAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<CMMFailureStateDto>>.CreateSuccess(_httpContextAccessor, cmmFailureStates, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<CMMFailureStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByManual/{id:int}")]
        [AuthorizePermission("CMMFailureState", "Read")]
        public async Task<IActionResult> GetAllCMMFailureStatesByManualAsync([FromRoute] int id)
        {
            try
            {
                var cmmFailureStates = await _manager.CMMFailureStateService.GetAllCMMFailureStateByManualAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<CMMFailureStateDto>>.CreateSuccess(_httpContextAccessor, cmmFailureStates, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<CMMFailureStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("CMMFailureState", "Read")]
        public async Task<IActionResult> GetOneCMMFailureStateByIdAsync([FromRoute] int id)
        {
            try
            {
                var cmmFailureState = await _manager.CMMFailureStateService.GetCMMFailureStateByIdAsync(id, false);
                return Ok(ApiResponse<CMMFailureStateDto>.CreateSuccess(_httpContextAccessor, cmmFailureState, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("CMMFailureState", "Write")]
        public async Task<IActionResult> CreateOneCMMFailureStateAsync([FromBody] CMMFailureStateDtoForInsertion cmmFailureStateDtoForInsertion)
        {
            try
            {
                var cmmFailureState = await _manager.CMMFailureStateService.CreateCMMFailureStateAsync(
                    cmmFailureStateDtoForInsertion
                );
                return Ok(ApiResponse<CMMFailureStateDto>.CreateSuccess(_httpContextAccessor, cmmFailureState, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("CMMFailureState", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromBody] CMMFailureStateDtoForUpdate cmmFailureStateDtoForUpdate)
        {
            try
            {
                var cmmFailureState = await _manager.CMMFailureStateService.UpdateCMMFailureStateAsync(cmmFailureStateDtoForUpdate);
                return Ok(ApiResponse<CMMFailureStateDto>.CreateSuccess(_httpContextAccessor, cmmFailureState, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("CMMFailureState", "Delete")]
        public async Task<IActionResult> DeleteOneCMMFailureStateAsync([FromRoute] int id)
        {
            try
            {
                var cmmFailureState = await _manager.CMMFailureStateService.DeleteCMMFailureStateAsync(id, false);
                return Ok(ApiResponse<CMMFailureStateDto>.CreateSuccess(_httpContextAccessor, cmmFailureState, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
