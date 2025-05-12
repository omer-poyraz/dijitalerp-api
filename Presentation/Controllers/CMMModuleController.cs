using Entities.DTOs.CMMModuleDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/CMMModule")]
    public class CMMModuleController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CMMModuleController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("CMMModule", "Read")]
        public async Task<IActionResult> GetAllCMMModulesAsync()
        {
            try
            {
                var users = await _manager.CMMModuleService.GetAllCMMModuleAsync(false);
                return Ok(ApiResponse<IEnumerable<CMMModuleDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<CMMModuleDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("CMMModule", "Read")]
        public async Task<IActionResult> GetOneCMMModuleByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMModuleService.GetCMMModuleByIdAsync(id, false);
                return Ok(ApiResponse<CMMModuleDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMModuleDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("CMMModule", "Write")]
        public async Task<IActionResult> CreateOneCMMModuleAsync([FromForm] CMMModuleDtoForInsertion cmmModuleDtoForInsertion)
        {
            try
            {
                if (cmmModuleDtoForInsertion.file != null && cmmModuleDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(cmmModuleDtoForInsertion.file, imgId, "CMMModule");
                    cmmModuleDtoForInsertion.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.CMMModuleService.CreateCMMModuleAsync(
                    cmmModuleDtoForInsertion
                );
                return Ok(ApiResponse<CMMModuleDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<CMMModuleDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("CMMModule", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromForm] CMMModuleDtoForUpdate cmmModuleDtoForUpdate)
        {
            try
            {
                if (cmmModuleDtoForUpdate.file != null && cmmModuleDtoForUpdate.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(cmmModuleDtoForUpdate.file, imgId, "CMMModule");
                    cmmModuleDtoForUpdate.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.CMMModuleService.UpdateCMMModuleAsync(cmmModuleDtoForUpdate);
                return Ok(ApiResponse<CMMModuleDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMModuleDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("AddFile")]
        [AuthorizePermission("CMMModule", "Write")]
        public async Task<IActionResult> AddFileCMMModuleAsync([FromForm] CMMModuleDtoForAddFile cmmModuleDtoForAddFile)
        {
            try
            {
                if (cmmModuleDtoForAddFile.file != null && cmmModuleDtoForAddFile.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(cmmModuleDtoForAddFile.file, imgId, "CMMModule");
                    cmmModuleDtoForAddFile.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.CMMModuleService.AddFileCMMModuleAsync(cmmModuleDtoForAddFile);
                return Ok(ApiResponse<CMMModuleDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMModuleDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("CMMModule", "Delete")]
        public async Task<IActionResult> DeleteOneCMMModuleAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.CMMModuleService.DeleteCMMModuleAsync(id, false);
                return Ok(ApiResponse<CMMModuleDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<CMMModuleDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
