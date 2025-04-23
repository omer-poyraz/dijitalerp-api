using Entities.Models;

namespace Entities.DTOs.EmployeeDto
{
    public class EmployeeDto
    {
        public int ID { get; init; }
        public string? File { get; init; }
        public string? Name { get; init; }
        public string? Surname { get; init; }
        public string? Email { get; init; }
        public string? Phone { get; init; }
        public string? Address { get; init; }
        public string? Field { get; init; }
        public DateTime? Birthday { get; init; }
        public DateTime? StartDate { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
