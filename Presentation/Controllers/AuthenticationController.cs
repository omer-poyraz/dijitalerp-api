using Entities.DTOs.UserDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponse<TokenDto>.CreateError(_httpContextAccessor, "Error.ValidationError", 400));

                if (!await _manager.AuthenticationService.ValidUser(userForAuthenticationDto))
                    return Unauthorized(ApiResponse<TokenDto>.CreateError(_httpContextAccessor, "Error.InvalidCredentials", 401));

                var token = await _manager.AuthenticationService.CreateToken(true);
                return Ok(ApiResponse<TokenDto>.CreateSuccess(_httpContextAccessor, token, "Success.LoginSuccess"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TokenDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPost("Register")]
        [AuthorizePermission("Authentication", "Write")]
        public async Task<IActionResult> Register([FromForm] UserForRegisterDto userForRegisterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponse<IdentityResult>.CreateError(_httpContextAccessor, "Error.ValidationError", 400));

                if (userForRegisterDto.file != null)
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    List<IFormFile> formFiles = new List<IFormFile> { userForRegisterDto.file };
                    var uploadResults = await FileManager.FileUpload(formFiles, imgId, "User");
                    userForRegisterDto.File = uploadResults.FirstOrDefault()?["FilesFullPath"]?.ToString() ?? string.Empty;
                }

                var result = await _manager.AuthenticationService.RegisterUser(userForRegisterDto);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ApiResponse<List<string>>.CreateError(_httpContextAccessor, "Error.RegisterFailed", 400));
                }

                return Ok(ApiResponse<IdentityResult>.CreateSuccess(_httpContextAccessor, result, "Success.RegisterSuccess"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<IdentityResult>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            try
            {
                var tokenDtoToReturn = await _manager.AuthenticationService.RefreshToken(tokenDto);
                return Ok(ApiResponse<TokenDto>.CreateSuccess(_httpContextAccessor, tokenDtoToReturn, "Success.TokenRefreshed"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse<TokenDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }
    }
}
