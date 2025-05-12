using Entities.Models;

namespace Entities.DTOs.CMMModuleDto
{
    public class CMMModuleDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
        public string? CMM { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
