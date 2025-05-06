using Entities.Models;

namespace Entities.DTOs.AssemblyQualityDto
{
    public class AssemblyQualityDto
    {
        public int ID { get; init; }
        public string? Description { get; init; }
        public string? Note { get; init; }
        public AssemblyFailureState? AssemblyFailureState { get; init; }
        public int? AssemblyFailureStateID { get; init; }
        public User? QualityOfficer { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
