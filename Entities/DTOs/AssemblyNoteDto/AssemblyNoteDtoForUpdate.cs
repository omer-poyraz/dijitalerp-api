namespace Entities.DTOs.AssemblyNoteDto
{
    public record AssemblyNoteDtoForUpdate : AssemblyNoteDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
