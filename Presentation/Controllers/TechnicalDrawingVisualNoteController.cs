using Entities.DTOs.TechnicalDrawingVisualNoteDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/TechnicalDrawingVisualNote")]
    public class TechnicalDrawingVisualNoteController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TechnicalDrawingVisualNoteController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("TechnicalDrawingVisualNote", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingVisualNotesAsync()
        {
            try
            {
                var techDrawing = await _manager.TechnicalDrawingVisualNoteService.GetAllTechnicalDrawingVisualNoteAsync(false);
                return Ok(ApiResponse<IEnumerable<TechnicalDrawingVisualNoteDto>>.CreateSuccess(_httpContextAccessor, techDrawing, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<TechnicalDrawingVisualNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("GetAllByDrawing/{id:int}")]
        [AuthorizePermission("TechnicalDrawingVisualNote", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingVisualNoteByDrawingAsync([FromRoute] int id)
        {
            try
            {
                var techDrawing = await _manager.TechnicalDrawingVisualNoteService.GetAllTechnicalDrawingVisualNoteByDrawingAsync(id, false);
                return Ok(ApiResponse<IEnumerable<TechnicalDrawingVisualNoteDto>>.CreateSuccess(_httpContextAccessor, techDrawing, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<TechnicalDrawingVisualNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("TechnicalDrawingVisualNote", "Read")]
        public async Task<IActionResult> GetOneTechnicalDrawingVisualNoteByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingVisualNoteService.GetTechnicalDrawingVisualNoteByIdAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingVisualNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingVisualNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("TechnicalDrawingVisualNote", "Write")]
        public async Task<IActionResult> CreateOneTechnicalDrawingVisualNoteAsync([FromForm] TechnicalDrawingVisualNoteDtoForInsertion technicalDrawingVisualNoteDtoForInsertion)
        {
            try
            {
                if (technicalDrawingVisualNoteDtoForInsertion.file != null && technicalDrawingVisualNoteDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(technicalDrawingVisualNoteDtoForInsertion.file, imgId, "TechnicalDrawingVisualNote");
                    technicalDrawingVisualNoteDtoForInsertion.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.TechnicalDrawingVisualNoteService.CreateTechnicalDrawingVisualNoteAsync(
                    technicalDrawingVisualNoteDtoForInsertion
                );
                return Ok(ApiResponse<TechnicalDrawingVisualNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingVisualNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("TechnicalDrawingVisualNote", "Delete")]
        public async Task<IActionResult> DeleteOneTechnicalDrawingVisualNoteAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingVisualNoteService.DeleteTechnicalDrawingVisualNoteAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingVisualNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingVisualNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
