using Entities.DTOs.DepartmentDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Department", "Read")]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            try
            {
                var users = await _manager.DepartmentService.GetAllDepartmentAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<DepartmentDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<DepartmentDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Department", "Read")]
        public async Task<IActionResult> GetOneDepartmentByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.DepartmentService.GetDepartmentByIdAsync(id, false);
                return Ok(ApiResponse<DepartmentDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<DepartmentDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Department", "Write")]
        public async Task<IActionResult> CreateOneDepartmentAsync(
            [FromBody] DepartmentDtoForInsertion departmentDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.DepartmentService.CreateDepartmentAsync(
                    departmentDtoForInsertion
                );
                return Ok(ApiResponse<DepartmentDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<DepartmentDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Department", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] DepartmentDtoForUpdate departmentDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.DepartmentService.UpdateDepartmentAsync(departmentDtoForUpdate);
                return Ok(ApiResponse<DepartmentDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<DepartmentDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Department", "Delete")]
        public async Task<IActionResult> DeleteOneDepartmentAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.DepartmentService.DeleteDepartmentAsync(id, false);
                return Ok(ApiResponse<DepartmentDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<DepartmentDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
