namespace Entities.DTOs.AssemblySuccessStateDto
{
    public record AssemblySuccessStateDtoForUpdate : AssemblySuccessStateDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
