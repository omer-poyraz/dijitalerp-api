using Entities.DTOs.AssemblyNoteDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/AssemblyNote")]
    public class AssemblyNoteController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssemblyNoteController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("AssemblyNote", "Read")]
        public async Task<IActionResult> GetAllAssemblyNotesAsync()
        {
            try
            {
                var users = await _manager.AssemblyNoteService.GetAllAssemblyNoteAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<AssemblyNoteDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<AssemblyNoteDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("AssemblyNote", "Read")]
        public async Task<IActionResult> GetOneAssemblyNoteByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyNoteService.GetAssemblyNoteByIdAsync(id, false);
                return Ok(ApiResponse<AssemblyNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("AssemblyNote", "Write")]
        public async Task<IActionResult> CreateOneAssemblyNoteAsync(
            [FromBody] AssemblyNoteDtoForInsertion assemblyNoteDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.AssemblyNoteService.CreateAssemblyNoteAsync(
                    assemblyNoteDtoForInsertion
                );
                return Ok(ApiResponse<AssemblyNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("AssemblyNote", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] AssemblyNoteDtoForUpdate assemblyNoteDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.AssemblyNoteService.UpdateAssemblyNoteAsync(assemblyNoteDtoForUpdate);
                return Ok(ApiResponse<AssemblyNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyNoteDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("AssemblyNote", "Delete")]
        public async Task<IActionResult> DeleteOneAssemblyNoteAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyNoteService.DeleteAssemblyNoteAsync(id, false);
                return Ok(ApiResponse<AssemblyNoteDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyNoteDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
