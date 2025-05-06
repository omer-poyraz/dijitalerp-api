using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.UserDto
{
    public abstract record UserDtoForManipulation
    {
        public string? File { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? TCKNO { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Address { get; set; }
        public string? Field { get; set; }
        public int? DepartmentID { get; set; }
        public string? Title { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
    }
}
