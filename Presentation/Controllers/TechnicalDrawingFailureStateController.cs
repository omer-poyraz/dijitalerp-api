using Entities.DTOs.TechnicalDrawingFailureStateDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/TechnicalDrawingFailureState")]
    public class TechnicalDrawingFailureStateController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TechnicalDrawingFailureStateController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("TechnicalDrawingFailureState", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingFailureStatesAsync()
        {
            try
            {
                var users = await _manager.TechnicalDrawingFailureStateService.GetAllTechnicalDrawingFailureStateAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<TechnicalDrawingFailureStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<TechnicalDrawingFailureStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByDrawing/{id:int}")]
        [AuthorizePermission("TechnicalDrawingFailureState", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingFailureStatesByDrawingAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.TechnicalDrawingFailureStateService.GetAllTechnicalDrawingFailureStateByDrawingAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<TechnicalDrawingFailureStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<TechnicalDrawingFailureStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("TechnicalDrawingFailureState", "Read")]
        public async Task<IActionResult> GetOneTechnicalDrawingFailureStateByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingFailureStateService.GetTechnicalDrawingFailureStateByIdAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("TechnicalDrawingFailureState", "Write")]
        public async Task<IActionResult> CreateOneTechnicalDrawingFailureStateAsync(
            [FromBody] TechnicalDrawingFailureStateDtoForInsertion technicalDrawingFailureStateDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.TechnicalDrawingFailureStateService.CreateTechnicalDrawingFailureStateAsync(
                    technicalDrawingFailureStateDtoForInsertion
                );
                return Ok(ApiResponse<TechnicalDrawingFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("TechnicalDrawingFailureState", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] TechnicalDrawingFailureStateDtoForUpdate technicalDrawingFailureStateDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.TechnicalDrawingFailureStateService.UpdateTechnicalDrawingFailureStateAsync(technicalDrawingFailureStateDtoForUpdate);
                return Ok(ApiResponse<TechnicalDrawingFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingFailureStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("TechnicalDrawingFailureState", "Delete")]
        public async Task<IActionResult> DeleteOneTechnicalDrawingFailureStateAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingFailureStateService.DeleteTechnicalDrawingFailureStateAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingFailureStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingFailureStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
