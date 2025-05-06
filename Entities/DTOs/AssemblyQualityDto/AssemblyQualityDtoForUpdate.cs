namespace Entities.DTOs.AssemblyQualityDto
{
    public record AssemblyQualityDtoForUpdate : AssemblyQualityDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
