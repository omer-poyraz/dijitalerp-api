using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Entities.DTOs.UserDto
{
    public record UserDto
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public string? TCKNO { get; set; }
        public string? PhoneNumber2 { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentID { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<IdentityRole>? Roles { get; init; }
        public DateTime CreateAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; init; } = DateTime.UtcNow;
    }
}
