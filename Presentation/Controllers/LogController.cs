using Entities.DTOs.LogDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Log")]
    public class LogController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Log", "Read")]
        public async Task<IActionResult> GetAllLogsAsync()
        {
            try
            {
                var logs = await _manager.LogService.GetAllLogsAsync(false);
                return Ok(ApiResponse<IEnumerable<LogDto>>.CreateSuccess(
                    _httpContextAccessor,
                    logs,
                    "Success.Listed"
                ));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<IEnumerable<LogDto>>.CreateError(
                    _httpContextAccessor,
                    "Error.ServerError"
                ));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Log", "Read")]
        public async Task<IActionResult> GetOneLogByIdAsync([FromRoute] int id)
        {
            try
            {
                var log = await _manager.LogService.GetLogByIdAsync(id, false);
                return Ok(ApiResponse<LogDto>.CreateSuccess(
                    _httpContextAccessor,
                    log,
                    "Success.Retrieved"
                ));
            }
            catch (Exception)
            {
                return NotFound(ApiResponse<LogDto>.CreateError(
                    _httpContextAccessor,
                    "Error.NotFound",
                    404
                ));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Log", "Delete")]
        public async Task<IActionResult> DeleteOneLogAsync([FromRoute] int id)
        {
            try
            {
                var log = await _manager.LogService.DeleteLogAsync(id, false);
                return Ok(ApiResponse<LogDto>.CreateSuccess(
                    _httpContextAccessor,
                    log,
                    "Success.Deleted"
                ));
            }
            catch (Exception)
            {
                return NotFound(ApiResponse<LogDto>.CreateError(
                    _httpContextAccessor,
                    "Error.NotFound",
                    404
                ));
            }
        }
    }
}