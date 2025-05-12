using Entities.DTOs.CMMDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/CMM")]
    public class CMMController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CMMController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("CMM", "Read")]
        public async Task<IActionResult> GetAllCMMsAsync()
        {
            try
            {
                var users = await _manager.CMMService.GetAllCMMAsync(false);
                return Ok(ApiResponse<IEnumerable<CMMDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ApiResponse<IEnumerable<CMMDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("CMM", "Read")]
        public async Task<IActionResult> GetOneCMMByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMService.GetCMMByIdAsync(id, false);
                return Ok(ApiResponse<CMMDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("CMM", "Write")]
        public async Task<IActionResult> CreateOneCMMAsync([FromForm] CMMDtoForInsertion cmmDtoForInsertion)
        {
            try
            {
                if (cmmDtoForInsertion.file != null && cmmDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(cmmDtoForInsertion.file, imgId, "CMM");
                    cmmDtoForInsertion.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.CMMService.CreateCMMAsync(
                    cmmDtoForInsertion
                );
                return Ok(ApiResponse<CMMDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<CMMDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("CMM", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromForm] CMMDtoForUpdate cmmDtoForUpdate)
        {
            try
            {
                if (cmmDtoForUpdate.file != null && cmmDtoForUpdate.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(cmmDtoForUpdate.file, imgId, "CMM");
                    cmmDtoForUpdate.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.CMMService.UpdateCMMAsync(cmmDtoForUpdate);
                return Ok(ApiResponse<CMMDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("AddFile")]
        [AuthorizePermission("CMM", "Write")]
        public async Task<IActionResult> AddFileCMMAsync([FromForm] CMMDtoForAddFile cmmDtoForAddFile)
        {
            try
            {
                if (cmmDtoForAddFile.file != null && cmmDtoForAddFile.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(cmmDtoForAddFile.file, imgId, "CMM");
                    cmmDtoForAddFile.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.CMMService.AddFileCMMAsync(cmmDtoForAddFile);
                return Ok(ApiResponse<CMMDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("AddResultFile")]
        [AuthorizePermission("CMM", "Write")]
        public async Task<IActionResult> AddResultFileCMMAsync([FromForm] CMMDtoForAddResultFile cmmDtoForAddResultFile)
        {
            try
            {
                if (cmmDtoForAddResultFile.resultFile != null && cmmDtoForAddResultFile.resultFile.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(cmmDtoForAddResultFile.resultFile, imgId, "CMM");
                    cmmDtoForAddResultFile.ResultFiles = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.CMMService.AddResultFileCMMAsync(cmmDtoForAddResultFile);
                return Ok(ApiResponse<CMMDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("CMM", "Delete")]
        public async Task<IActionResult> DeleteOneCMMAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMService.DeleteCMMAsync(id, false);
                return Ok(ApiResponse<CMMDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
