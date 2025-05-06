using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Entities.DTOs.UserDto
{
    public record UserDto
    {
        public string? UserId { get; init; }
        public string? File { get; init; } = "https://www.dijitalerpyazilim.com/themes/dijitalerp/assets/img/favicon-96x96.png";
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; init; }
        public string? TCKNO { get; init; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; init; }
        public string? PhoneNumber2 { get; init; }
        public string? Address { get; init; }
        public string? Field { get; init; }
        public Department? Department { get; init; }
        public int? DepartmentID { get; init; }
        public string? RefreshToken { get; init; }
        public string? Title { get; init; }
        public DateTime? Birthday { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? DepartureDate { get; init; }
        public string? Gender { get; init; }
        public bool? IsActive { get; init; }
        public DateTime RefreshTokenExpireTime { get; init; }
        public ICollection<IdentityRole>? Roles { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
