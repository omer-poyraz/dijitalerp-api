using Entities.DTOs.TechnicalDrawingDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/TechnicalDrawing")]
    public class TechnicalDrawingController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TechnicalDrawingController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("TechnicalDrawing", "Read")]
        public async Task<IActionResult> GetAllTechnicalDrawingsAsync()
        {
            try
            {
                var users = await _manager.TechnicalDrawingService.GetAllTechnicalDrawingAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<TechnicalDrawingDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<TechnicalDrawingDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("TechnicalDrawing", "Read")]
        public async Task<IActionResult> GetOneTechnicalDrawingByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingService.GetTechnicalDrawingByIdAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("TechnicalDrawing", "Write")]
        public async Task<IActionResult> CreateOneTechnicalDrawingAsync(
            [FromForm] TechnicalDrawingDtoForInsertion technicalDrawingDtoForInsertion
        )
        {
            try
            {
                if (technicalDrawingDtoForInsertion.file != null && technicalDrawingDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(technicalDrawingDtoForInsertion.file, imgId, "TechnicalDrawing");
                    technicalDrawingDtoForInsertion.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.TechnicalDrawingService.CreateTechnicalDrawingAsync(
                    technicalDrawingDtoForInsertion
                );
                return Ok(ApiResponse<TechnicalDrawingDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<TechnicalDrawingDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("TechnicalDrawing", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromForm] TechnicalDrawingDtoForUpdate technicalDrawingDtoForUpdate
        )
        {
            try
            {
                if (technicalDrawingDtoForUpdate.file != null && technicalDrawingDtoForUpdate.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(technicalDrawingDtoForUpdate.file, imgId, "TechnicalDrawing");
                    technicalDrawingDtoForUpdate.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.TechnicalDrawingService.UpdateTechnicalDrawingAsync(technicalDrawingDtoForUpdate);
                return Ok(ApiResponse<TechnicalDrawingDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("AddFile")]
        [AuthorizePermission("TechnicalDrawing", "Write")]
        public async Task<IActionResult> AddFileTechnicalDrawingAsync(
            [FromForm] TechnicalDrawingDtoForAddFile technicalDrawingDtoForAddFile
        )
        {
            try
            {
                if (technicalDrawingDtoForAddFile.file != null && technicalDrawingDtoForAddFile.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(technicalDrawingDtoForAddFile.file, imgId, "TechnicalDrawing");
                    technicalDrawingDtoForAddFile.Files = uploadResults.Select(uploadResult => uploadResult["FilesFullPath"].ToString()).ToList()!;
                }

                var user = await _manager.TechnicalDrawingService.AddFileTechnicalDrawingAsync(technicalDrawingDtoForAddFile);
                return Ok(ApiResponse<TechnicalDrawingDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("TechnicalDrawing", "Delete")]
        public async Task<IActionResult> DeleteOneTechnicalDrawingAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.TechnicalDrawingService.DeleteTechnicalDrawingAsync(id, false);
                return Ok(ApiResponse<TechnicalDrawingDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<TechnicalDrawingDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
