using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Extensions
{
    public class AuthorizePermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _serviceName;
        private readonly string _permissionType;

        public AuthorizePermissionAttribute(string serviceName, string permissionType)
        {
            _serviceName = serviceName;
            _permissionType = permissionType;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userManager = context.HttpContext.RequestServices.GetService<UserManager<User>>();
            var repositoryManager = context.HttpContext.RequestServices.GetService<IRepositoryManager>();

            if (userManager == null)
            {
                context.Result = new ObjectResult(
                    new { statusCode = 500, message = "Kullanıcı yönetim servisi bulunamadı." }
                )
                {
                    StatusCode = 500,
                };
                return;
            }

            var userName = context.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                context.Result = new ObjectResult(
                    new { statusCode = 403, message = "Yetkiniz yok!" }
                )
                {
                    StatusCode = 403,
                };
                return;
            }

            var user = await userManager.FindByNameAsync(userName);
            var userId = user?.Id;

            var userRoles = await userManager.GetRolesAsync(user!);
            if (userRoles == null || userRoles.Count == 0)
            {
                var newUser = await repositoryManager.UserRepository.GetOneUserByIdAsync(userId, false);
                if (newUser?.Roles != null && newUser.Roles.Any())
                    userRoles = new List<string> { newUser.Roles.First().Name };
            }
            if (userRoles!.Contains("Super Admin") || userRoles.Contains("Admin"))
            {
                return;
            }

            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new ObjectResult(
                    new { statusCode = 403, message = "Yetkiniz yok!" }
                )
                {
                    StatusCode = 403,
                };
                return;
            }

            var userPermissionService =
                context.HttpContext.RequestServices.GetService<IUserPermissionService>();

            if (userPermissionService == null)
            {
                context.Result = new ObjectResult(
                    new { statusCode = 500, message = "Yetki servisi bulunamadı." }
                )
                {
                    StatusCode = 500,
                };
                return;
            }

            var hasPermission = await userPermissionService.HasPermissionAsync(
                userId,
                _serviceName,
                _permissionType
            );

            if (!hasPermission)
            {
                context.Result = new ObjectResult(
                    new { statusCode = 403, message = "Yetkiniz yok!" }
                )
                {
                    StatusCode = 403,
                };
            }
        }
    }
}
