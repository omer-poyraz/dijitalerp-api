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

        await CreateUserIfNotExists(userManager, authService, "SuperAdminInfo", "Super Admin");
        await CreateUserIfNotExists(userManager, authService, "AdminInfo", "Admin");
        await CreateUserIfNotExists(userManager, authService, "PersonelInfo", "Personel");

        await _next(context);
    }

    private async Task CreateUserIfNotExists(
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
            File = userInfo["File"],
            FirstName = userInfo["FirstName"],
            LastName = userInfo["LastName"],
            UserName = userInfo["UserName"],
            Password = userInfo["Password"],
            Email = userInfo["Email"],
            TCKNO = userInfo["TCKNO"],
            Title = userInfo["Title"],
            Field = userInfo["Field"],
            IsActive = userInfo["IsActive"],
            DepartureDate = userInfo["DepartureDate"],
            StartDate = userInfo["StartDate"],
            Birthday = userInfo["Birthday"],
            PhoneNumber = userInfo["PhoneNumber"],
            PhoneNumber2 = userInfo["PhoneNumber2"],
            Address = userInfo["Address"],
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