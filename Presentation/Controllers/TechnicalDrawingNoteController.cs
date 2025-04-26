using Entities.DTOs.TechnicalDrawingNoteDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/TechnicalDrawingNote")]
    public class TechnicalDrawingNoteController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TechnicalDrawingNoteController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("TechnicalDrawingNote", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingNotesAsync()
        {
            try
            {
                var users = await _manager.TechnicalDrawingNoteService.GetAllTechnicalDrawingNoteAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<TechnicalDrawingNoteDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<TechnicalDrawingNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("GetAllByDrawing/{id:int}")]
        [AuthorizePermission("TechnicalDrawingNote", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingNotesAsync([FromRoute] int id)
        {
            try
            {
                var users = await _manager.TechnicalDrawingNoteService.GetAllTechnicalDrawingNoteByDrawingAsync(id, false);
                return Ok(
                    ApiResponse<IEnumerable<TechnicalDrawingNoteDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<TechnicalDrawingNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("TechnicalDrawingNote", "Read")]
        public async Task<IActionResult> GetOneTechnicalDrawingNoteByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingNoteService.GetTechnicalDrawingNoteByIdAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("TechnicalDrawingNote", "Write")]
        public async Task<IActionResult> CreateOneTechnicalDrawingNoteAsync(
            [FromBody] TechnicalDrawingNoteDtoForInsertion technicalDrawingNoteDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.TechnicalDrawingNoteService.CreateTechnicalDrawingNoteAsync(
                    technicalDrawingNoteDtoForInsertion
                );
                return Ok(ApiResponse<TechnicalDrawingNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("TechnicalDrawingNote", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] TechnicalDrawingNoteDtoForUpdate technicalDrawingNoteDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.TechnicalDrawingNoteService.UpdateTechnicalDrawingNoteAsync(technicalDrawingNoteDtoForUpdate);
                return Ok(ApiResponse<TechnicalDrawingNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("TechnicalDrawingNote", "Delete")]
        public async Task<IActionResult> DeleteOneTechnicalDrawingNoteAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingNoteService.DeleteTechnicalDrawingNoteAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
