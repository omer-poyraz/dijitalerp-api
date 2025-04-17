using Entities.DTOs.AssemblyManuelDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/AssemblyManuel")]
    public class AssemblyManuelController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssemblyManuelController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("AssemblyManuel", "Read")]
        public async Task<IActionResult> GetAllAssemblyManuelsAsync()
        {
            try
            {
                var users = await _manager.AssemblyManuelService.GetAllAssemblyManuelAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<AssemblyManuelDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<AssemblyManuelDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("AssemblyManuel", "Read")]
        public async Task<IActionResult> GetOneAssemblyManuelByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyManuelService.GetAssemblyManuelByIdAsync(id, false);
                return Ok(ApiResponse<AssemblyManuelDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyManuelDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("AssemblyManuel", "Write")]
        public async Task<IActionResult> CreateOneAssemblyManuelAsync(
            [FromForm] AssemblyManuelDtoForInsertion assemblyManuelDtoForInsertion
        )
        {
            try
            {
                if (assemblyManuelDtoForInsertion.file != null && assemblyManuelDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(assemblyManuelDtoForInsertion.file, imgId, "AssemblyManuel");
                    assemblyManuelDtoForInsertion.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.AssemblyManuelService.CreateAssemblyManuelAsync(
                    assemblyManuelDtoForInsertion
                );
                return Ok(ApiResponse<AssemblyManuelDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyManuelDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("AssemblyManuel", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromForm] AssemblyManuelDtoForUpdate assemblyManuelDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.AssemblyManuelService.UpdateAssemblyManuelAsync(assemblyManuelDtoForUpdate);
                return Ok(ApiResponse<AssemblyManuelDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyManuelDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("AssemblyManuel", "Delete")]
        public async Task<IActionResult> DeleteOneAssemblyManuelAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.AssemblyManuelService.DeleteAssemblyManuelAsync(id, false);
                return Ok(ApiResponse<AssemblyManuelDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<AssemblyManuelDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
