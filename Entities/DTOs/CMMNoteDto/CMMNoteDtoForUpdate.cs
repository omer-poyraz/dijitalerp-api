namespace Entities.DTOs.CMMNoteDto
{
    public record CMMNoteDtoForUpdate : CMMNoteDtoForManipulation
    {
        public int ID { get; init; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
