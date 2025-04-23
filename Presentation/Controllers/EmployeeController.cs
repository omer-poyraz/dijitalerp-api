using Entities.DTOs.EmployeeDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Employee", "Read")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            try
            {
                var users = await _manager.EmployeeService.GetAllEmployeeAsync(false);
                return Ok(ApiResponse<IEnumerable<EmployeeDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<EmployeeDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Employee", "Read")]
        public async Task<IActionResult> GetOneEmployeeByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.EmployeeService.GetEmployeeByIdAsync(id, false);
                return Ok(ApiResponse<EmployeeDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<EmployeeDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Employee", "Write")]
        public async Task<IActionResult> CreateOneEmployeeAsync([FromForm] EmployeeDtoForInsertion employeeDtoForInsertion)
        {
            try
            {
                if (employeeDtoForInsertion.file != null)
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var newList = new List<string>();
                    List<IFormFile> filesList = new List<IFormFile> { employeeDtoForInsertion.file };
                    var uploadResults = await FileManager.FileUpload(filesList, imgId, "Employee");
                    employeeDtoForInsertion.File = uploadResults.FirstOrDefault()?["FilesFullPath"]?.ToString() ?? string.Empty;
                }

                var user = await _manager.EmployeeService.CreateEmployeeAsync(employeeDtoForInsertion);
                return Ok(ApiResponse<EmployeeDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<EmployeeDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Employee", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromForm] EmployeeDtoForUpdate employeeDtoForUpdate)
        {
            try
            {
                if (employeeDtoForUpdate.file != null)
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var newList = new List<string>();
                    List<IFormFile> filesList = new List<IFormFile> { employeeDtoForUpdate.file };
                    var uploadResults = await FileManager.FileUpload(filesList, imgId, "Employee");
                    employeeDtoForUpdate.File = uploadResults.FirstOrDefault()?["FilesFullPath"]?.ToString() ?? string.Empty;
                }
                var user = await _manager.EmployeeService.UpdateEmployeeAsync(employeeDtoForUpdate);
                return Ok(ApiResponse<EmployeeDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<EmployeeDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Employee", "Delete")]
        public async Task<IActionResult> DeleteOneEmployeeAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.EmployeeService.DeleteEmployeeAsync(id, false);
                return Ok(ApiResponse<EmployeeDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<EmployeeDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
