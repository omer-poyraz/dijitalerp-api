using Entities.DTOs.ServicesDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Services")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServicesController(IServiceManager manager, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Services", "Read")]
        public async Task<IActionResult> GetAllServicessAsync()
        {
            try
            {
                var users = await _manager.ServicesService.GetAllServicesAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<ServicesDto>>.CreateSuccess(_httpContextAccessor, users, "Success.Listed")
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<ServicesDto>>.CreateError(_httpContextAccessor, "Error.NotFound")
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Services", "Read")]
        public async Task<IActionResult> GetOneServicesByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ServicesService.GetServicesByIdAsync(id, false);
                return Ok(ApiResponse<ServicesDto>.CreateSuccess(_httpContextAccessor, user, "Success.Retrieved"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Services", "Write")]
        public async Task<IActionResult> CreateOneServicesAsync(
            [FromBody] ServicesDtoForInsertion servicesDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.ServicesService.CreateServicesAsync(
                    servicesDtoForInsertion
                );
                return Ok(ApiResponse<ServicesDto>.CreateSuccess(_httpContextAccessor, user, "Success.Created"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Services", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] ServicesDtoForUpdate servicesDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.ServicesService.UpdateServicesAsync(servicesDtoForUpdate);
                return Ok(ApiResponse<ServicesDto>.CreateSuccess(_httpContextAccessor, user, "Success.Updated"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.CreateError(_httpContextAccessor, "Error.ServerError"));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Services", "Delete")]
        public async Task<IActionResult> DeleteOneServicesAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ServicesService.DeleteServicesAsync(id, false);
                return Ok(ApiResponse<ServicesDto>.CreateSuccess(_httpContextAccessor, user, "Success.Deleted"));
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.CreateError(_httpContextAccessor, "Error.NotFound"));
            }
        }
    }
}
