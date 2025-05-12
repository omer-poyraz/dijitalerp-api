using Entities.DTOs.CMMSuccessStateDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/CMMSuccessState")]
    public class CMMSuccessStateController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CMMSuccessStateController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("CMMSuccessState", "Read")]
        public async Task<IActionResult> GetAllCMMSuccessStatesAsync()
        {
            try
            {
                var users = await _manager.CMMSuccessStateService.GetAllCMMSuccessStateAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<CMMSuccessStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<CMMSuccessStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByManual/{id:int}")]
        [AuthorizePermission("CMMSuccessState", "Read")]
        public async Task<IActionResult> GetAllCMMSuccessStatesAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.CMMSuccessStateService.GetAllCMMSuccessStateByManualAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<CMMSuccessStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<CMMSuccessStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("CMMSuccessState", "Read")]
        public async Task<IActionResult> GetOneCMMSuccessStateByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMSuccessStateService.GetCMMSuccessStateByIdAsync(id, false);
                return Ok(ApiResponse<CMMSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMSuccessStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("CMMSuccessState", "Write")]
        public async Task<IActionResult> CreateOneCMMSuccessStateAsync(
            [FromBody] CMMSuccessStateDtoForInsertion cmmSuccessStateDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.CMMSuccessStateService.CreateCMMSuccessStateAsync(
                    cmmSuccessStateDtoForInsertion
                );
                return Ok(ApiResponse<CMMSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMSuccessStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("CMMSuccessState", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] CMMSuccessStateDtoForUpdate cmmSuccessStateDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.CMMSuccessStateService.UpdateCMMSuccessStateAsync(cmmSuccessStateDtoForUpdate);
                return Ok(ApiResponse<CMMSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMSuccessStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("CMMSuccessState", "Delete")]
        public async Task<IActionResult> DeleteOneCMMSuccessStateAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMSuccessStateService.DeleteCMMSuccessStateAsync(id, false);
                return Ok(ApiResponse<CMMSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMSuccessStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
