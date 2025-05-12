namespace Entities.DTOs.CMMNoteDto
{
    public record CMMNoteDtoForInsertion : CMMNoteDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
