using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public string? TCKNO { get; set; }
        public string? PhoneNumber2 { get; set; }
        [ForeignKey("DepartmentID")]
        public Department? Department { get; set; }
        public int? DepartmentID { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
        public ICollection<IdentityRole>? Roles { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            UserId = Id;
        }
    }
}
