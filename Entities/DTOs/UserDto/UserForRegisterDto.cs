using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.UserDto
{
    public record UserForRegisterDto
    {
        public IFormFile? file { get; set; }
        public string? File { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? TCKNO { get; set; }
        public string? Field { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Address { get; set; }
        public int? DepartmentID { get; set; }
        public string? Title { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
}
