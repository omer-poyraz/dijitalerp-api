using Entities.DTOs.TechnicalDrawingQualityDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/TechnicalDrawingQuality")]
    public class TechnicalDrawingQualityController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TechnicalDrawingQualityController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("TechnicalDrawingQuality", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingQualityAsync()
        {
            try
            {
                var users = await _manager.TechnicalDrawingQualityService.GetAllTechnicalDrawingQualityAsync(false);
                return Ok(ApiResponse<IEnumerable<TechnicalDrawingQualityDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<TechnicalDrawingQualityDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("GetAllByFailure/{id:int}")]
        [AuthorizePermission("TechnicalDrawingQuality", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingQualityByFailureAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.TechnicalDrawingQualityService.GetAllTechnicalDrawingQualityByFailureAsync(id, false);
                return Ok(ApiResponse<IEnumerable<TechnicalDrawingQualityDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<TechnicalDrawingQualityDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("TechnicalDrawingQuality", "Read")]
        public async Task<IActionResult> GetOneTechnicalDrawingQualityByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingQualityService.GetTechnicalDrawingQualityByIdAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingQualityDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("TechnicalDrawingQuality", "Write")]
        public async Task<IActionResult> CreateOneTechnicalDrawingQualityAsync([FromBody] TechnicalDrawingQualityDtoForInsertion technicalDrawingQualityDtoForInsertion)
        {
            try
            {
                var user = await _manager.TechnicalDrawingQualityService.CreateTechnicalDrawingQualityAsync(technicalDrawingQualityDtoForInsertion);
                return Ok(ApiResponse<TechnicalDrawingQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingQualityDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("TechnicalDrawingQuality", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromBody] TechnicalDrawingQualityDtoForUpdate technicalDrawingQualityDtoForUpdate)
        {
            try
            {
                var user = await _manager.TechnicalDrawingQualityService.UpdateTechnicalDrawingQualityAsync(technicalDrawingQualityDtoForUpdate);
                return Ok(ApiResponse<TechnicalDrawingQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingQualityDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("TechnicalDrawingQuality", "Delete")]
        public async Task<IActionResult> DeleteOneTechnicalDrawingQualityAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingQualityService.DeleteTechnicalDrawingQualityAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingQualityDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingQualityDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
