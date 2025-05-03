using Entities.DTOs.AssemblyVisualNoteDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/AssemblyVisualNote")]
    public class AssemblyVisualNoteController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssemblyVisualNoteController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("AssemblyVisualNote", "Read")]
        public async Task<IActionResult> GetAllAssemblyVisualNotesAsync()
        {
            try
            {
                var users = await _manager.AssemblyVisualNoteService.GetAllAssemblyVisualNoteAsync(false);
                return Ok(ApiResponse<IEnumerable<AssemblyVisualNoteDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<AssemblyVisualNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("GetAllByDrawing/{id:int}")]
        [AuthorizePermission("AssemblyVisualNote", "Read")]
        public async Task<IActionResult> GetAllAssemblyVisualNoteByDrawingAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyVisualNoteService.GetAllAssemblyVisualNoteByDrawingAsync(id, false);
                return Ok(ApiResponse<IEnumerable<AssemblyVisualNoteDto>>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ApiResponse<AssemblyVisualNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("AssemblyVisualNote", "Read")]
        public async Task<IActionResult> GetOneAssemblyVisualNoteByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyVisualNoteService.GetAssemblyVisualNoteByIdAsync(id, false);
                return Ok(ApiResponse<AssemblyVisualNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyVisualNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("AssemblyVisualNote", "Write")]
        public async Task<IActionResult> CreateOneAssemblyVisualNoteAsync([FromForm] AssemblyVisualNoteDtoForInsertion assemblyVisualNoteDtoForInsertion)
        {
            try
            {
                if (assemblyVisualNoteDtoForInsertion.file != null && assemblyVisualNoteDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(assemblyVisualNoteDtoForInsertion.file, imgId, "AssemblyVisualNote");
                    assemblyVisualNoteDtoForInsertion.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.AssemblyVisualNoteService.CreateAssemblyVisualNoteAsync(assemblyVisualNoteDtoForInsertion);
                return Ok(ApiResponse<AssemblyVisualNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyVisualNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("AssemblyVisualNote", "Delete")]
        public async Task<IActionResult> DeleteOneAssemblyVisualNoteAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyVisualNoteService.DeleteAssemblyVisualNoteAsync(id, false);
                return Ok(ApiResponse<AssemblyVisualNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyVisualNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
