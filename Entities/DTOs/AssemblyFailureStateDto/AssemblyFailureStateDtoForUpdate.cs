namespace Entities.DTOs.AssemblyFailureStateDto
{
    public record AssemblyFailureStateDtoForUpdate : AssemblyFailureStateDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
