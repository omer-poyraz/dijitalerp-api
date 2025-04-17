using Entities.DTOs.UserDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Services.Contracts;

public class CreateInitialUsersMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public CreateInitialUsersMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Items["CreateInitialUsersMiddlewareRunning"] = true;
        var authService = context.RequestServices.GetRequiredService<IAuthenticationService>();
        var userManager = context.RequestServices.GetRequiredService<UserManager<User>>();
        var userPermissionService = context.RequestServices.GetRequiredService<IUserPermissionService>();

        await CreateUserIfNotExists(context, userManager, authService, "SuperAdminInfo", "Super Admin");
        await CreateUserIfNotExists(context, userManager, authService, "AdminInfo", "Admin");
        await CreateUserIfNotExists(context, userManager, authService, "PersonelInfo", "Personel");

        await _next(context);
    }

    private async Task CreateUserIfNotExists(
        HttpContext context,
        UserManager<User> userManager,
        IAuthenticationService authService,
        string configSectionName,
        string roleName)
    {
        var usersInRole = await userManager.GetUsersInRoleAsync(roleName);
        if (usersInRole.Any())
        {
            return;
        }

        var userInfo = _configuration.GetSection(configSectionName);

        if (userInfo == null || !userInfo.Exists())
        {
            Console.WriteLine($"{configSectionName} yapılandırma bilgisi bulunamadı!");
            return;
        }

        var userBody = new
        {
            FirstName = userInfo["FirstName"],
            LastName = userInfo["LastName"],
            UserName = userInfo["UserName"],
            Password = userInfo["Password"],
            Email = userInfo["Email"],
            TCKNO = userInfo["TCKNO"],
            Title = userInfo["Title"],
            PhoneNumber = userInfo["PhoneNumber"],
            PhoneNumber2 = userInfo["PhoneNumber2"],
            Gender = userInfo["Gender"],
            Roles = new[] { userInfo["Roles"] }
        };

        var jsonBody = JsonConvert.SerializeObject(userBody);

        try
        {
            var registerDto = JsonConvert.DeserializeObject<UserForRegisterDto>(jsonBody);
            var result = await authService.RegisterUser(registerDto!);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.WriteLine($"{roleName} kullanıcısı oluşturulamadı: {errors}");
            }
            else
            {
                Console.WriteLine($"{roleName} kullanıcısı başarıyla oluşturuldu.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{roleName} kullanıcısı oluşturulurken hata: {ex.Message}");
        }
    }
}