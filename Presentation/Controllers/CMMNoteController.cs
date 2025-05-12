using Entities.DTOs.CMMNoteDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/CMMNote")]
    public class CMMNoteController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CMMNoteController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("CMMNote", "Read")]
        public async Task<IActionResult> GetAllCMMNotesAsync()
        {
            try
            {
                var users = await _manager.CMMNoteService.GetAllCMMNoteAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<CMMNoteDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<CMMNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByManual/{id:int}")]
        [AuthorizePermission("CMMNote", "Read")]
        public async Task<IActionResult> GetAllCMMNotesAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.CMMNoteService.GetAllCMMNoteByManualAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<CMMNoteDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<CMMNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("CMMNote", "Read")]
        public async Task<IActionResult> GetOneCMMNoteByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMNoteService.GetCMMNoteByIdAsync(id, false);
                return Ok(ApiResponse<CMMNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("CMMNote", "Write")]
        public async Task<IActionResult> CreateOneCMMNoteAsync(
            [FromBody] CMMNoteDtoForInsertion cmmNoteDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.CMMNoteService.CreateCMMNoteAsync(
                    cmmNoteDtoForInsertion
                );
                return Ok(ApiResponse<CMMNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("CMMNote", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] CMMNoteDtoForUpdate cmmNoteDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.CMMNoteService.UpdateCMMNoteAsync(cmmNoteDtoForUpdate);
                return Ok(ApiResponse<CMMNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("CMMNote", "Delete")]
        public async Task<IActionResult> DeleteOneCMMNoteAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMNoteService.DeleteCMMNoteAsync(id, false);
                return Ok(ApiResponse<CMMNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
