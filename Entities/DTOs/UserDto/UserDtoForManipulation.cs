using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.UserDto
{
    public abstract record UserDtoForManipulation
    {
        [MaxLength(20)]
        public string? FirstName { get; init; }

        [MaxLength(20)]
        public string? LastName { get; init; }

        [MaxLength(20)]
        public string? UserName { get; init; }

        [MaxLength(30)]
        public string? Email { get; init; }

        [MaxLength(20)]
        public string? PhoneNumber { get; init; }
        public string? PhoneNumber2 { get; init; }
        public string? Gender { get; init; }
        public string? TCKNO { get; set; }
        public int? DepartmentID { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
