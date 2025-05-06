using System.Text.Json;
using Entities.DTOs.UserDto;
using Entities.RequestFeature.User;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("User", "Read")]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] UserParameters userParameters)
        {
            try
            {
                var users = await _manager.UserService.GetAllUsersAsync(userParameters, false);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(users.metaData));
                return Ok(ApiResponse<IEnumerable<UserDto>>.CreateSuccess(_httpContextAccessor, users.userDtos, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<UserDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("GetAllByQuality")]
        [AuthorizePermission("User", "Read")]
        public async Task<IActionResult> GetAllUsersByQualityAsync()
        {
            try
            {
                var users = await _manager.UserService.GetAllUserByQualityAsync(false);
                return Ok(ApiResponse<IEnumerable<UserDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<IEnumerable<UserDto>>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpGet("Get/{userId}")]
        [AuthorizePermission("User", "Read")]
        public async Task<IActionResult> GetOneUserByIdAsync([FromRoute] string? userId)
        {
            try
            {
                var user = await _manager.UserService.GetOneUserByIdAsync(userId, false);
                return Ok(ApiResponse<UserDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<UserDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("User", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync([FromForm] UserDtoForUpdate userDtoForUpdate)
        {
            try
            {
                if (userDtoForUpdate.file != null)
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    List<IFormFile> formFiles = new List<IFormFile> { userDtoForUpdate.file };
                    var uploadResults = await FileManager.FileUpload(formFiles, imgId, "User");
                    userDtoForUpdate.File = uploadResults.FirstOrDefault()?["FilesFullPath"]?.ToString() ?? string.Empty;
                }
                var user = await _manager.UserService.UpdateOneUserAsync(userDtoForUpdate.UserId, userDtoForUpdate, false);
                return Ok(ApiResponse<UserDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<UserDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{userId}")]
        [AuthorizePermission("User", "Delete")]
        public async Task<IActionResult> DeleteOneUserAsync([FromRoute] string? userId)
        {
            try
            {
                var user = await _manager.UserService.DeleteOneUserAsync(userId, false);
                return Ok(ApiResponse<UserDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<UserDto>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpPut("ChangePassword/{userId}")]
        [AuthorizePermission("User", "Write")]
        public async Task<IActionResult> ChangePaswordAsync([FromRoute] string? userId, [FromBody] UserDtoForChangePassword changePassword)
        {
            try
            {
                var user = await _manager.UserService.ChangePasswordAsync(userId, changePassword.CurrentPassword!, changePassword.NewPassword!, false);
                return Ok(ApiResponse<UserDto>.CreateSuccess(_httpContextAccessor, user, "Success.PasswordChanged"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<UserDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpGet("ResetPassword/{mail}")]
        public async Task<IActionResult> ResetPasswordAsync([FromRoute] string? mail)
        {
            try
            {
                var result = await _manager.UserService.ResetPasswordAsync(mail);
                return Ok(ApiResponse<bool>.CreateSuccess(_httpContextAccessor, result, "Success.PasswordReset"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<string>.CreateError(_httpContextAccessor, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.CreateError(_httpContextAccessor, ex.Message));
            }
        }
    }
}
