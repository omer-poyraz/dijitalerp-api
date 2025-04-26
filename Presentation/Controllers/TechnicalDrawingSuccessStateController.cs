using Entities.DTOs.TechnicalDrawingSuccessStateDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/TechnicalDrawingSuccessState")]
    public class TechnicalDrawingSuccessStateController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TechnicalDrawingSuccessStateController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("TechnicalDrawingSuccessState", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingSuccessStatesAsync()
        {
            try
            {
                var users = await _manager.TechnicalDrawingSuccessStateService.GetAllTechnicalDrawingSuccessStateAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<TechnicalDrawingSuccessStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<TechnicalDrawingSuccessStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByManual/{id:int}")]
        [AuthorizePermission("TechnicalDrawingSuccessState", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingSuccessStatesAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.TechnicalDrawingSuccessStateService.GetAllTechnicalDrawingSuccessStateByDrawingAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<TechnicalDrawingSuccessStateDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<TechnicalDrawingSuccessStateDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("TechnicalDrawingSuccessState", "Read")]
        public async Task<IActionResult> GetOneTechnicalDrawingSuccessStateByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingSuccessStateService.GetTechnicalDrawingSuccessStateByIdAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("TechnicalDrawingSuccessState", "Write")]
        public async Task<IActionResult> CreateOneTechnicalDrawingSuccessStateAsync([FromBody] TechnicalDrawingSuccessStateDtoForInsertion technicalDrawingSuccessStateDtoForInsertion)
        {
            try
            {
                var user = await _manager.TechnicalDrawingSuccessStateService.CreateTechnicalDrawingSuccessStateAsync(
                    technicalDrawingSuccessStateDtoForInsertion
                );
                return Ok(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("TechnicalDrawingSuccessState", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] TechnicalDrawingSuccessStateDtoForUpdate technicalDrawingSuccessStateDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.TechnicalDrawingSuccessStateService.UpdateTechnicalDrawingSuccessStateAsync(technicalDrawingSuccessStateDtoForUpdate);
                return Ok(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("TechnicalDrawingSuccessState", "Delete")]
        public async Task<IActionResult> DeleteOneTechnicalDrawingSuccessStateAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingSuccessStateService.DeleteTechnicalDrawingSuccessStateAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingSuccessStateDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
