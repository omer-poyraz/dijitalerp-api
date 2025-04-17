using Entities.Models;

namespace Entities.DTOs.DepartmentDto
{
    public class DepartmentDto
    {
        public int ID { get; init; }
        public string? Name { get; init; }
        public string? UserId { get; init; }
        public User? User { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
