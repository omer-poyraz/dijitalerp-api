using Entities.DTOs.UserPermissionDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/UserPermission")]
    public class UserPermissionController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserPermissionController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("UserPermission", "Read")]
        public async Task<IActionResult> GetAllUserPermissionsAsync()
        {
            try
            {
                var users = await _manager.UserPermissionService.GetAllUserPermissionsAsync(false);
                return Ok(ApiResponse<IEnumerable<UserPermissionDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<UserPermissionDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("UserPermission", "Read")]
        public async Task<IActionResult> GetOneUserPermissionByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.UserPermissionService.GetUserPermissionByIdAsync(id, false);
                return Ok(ApiResponse<UserPermissionDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("UserPermission", "Write")]
        public async Task<IActionResult> CreateOneUserPermissionAsync([FromBody] UserPermissionDtoForInsertion userPermissionDtoForInsertion)
        {
            try
            {
                var user = await _manager.UserPermissionService.CreateUserPermissionAsync(userPermissionDtoForInsertion);
                return Ok(ApiResponse<UserPermissionDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("UserPermission", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] UserPermissionDtoForUpdate userPermissionDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.UserPermissionService.UpdateUserPermissionAsync(userPermissionDtoForUpdate);
                return Ok(ApiResponse<UserPermissionDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("UserPermission", "Delete")]
        public async Task<IActionResult> DeleteOneUserPermissionAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.UserPermissionService.DeleteUserPermissionAsync(id, false);
                return Ok(ApiResponse<UserPermissionDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
