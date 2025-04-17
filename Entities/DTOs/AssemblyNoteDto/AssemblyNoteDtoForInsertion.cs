namespace Entities.DTOs.AssemblyNoteDto
{
    public record AssemblyNoteDtoForInsertion : AssemblyNoteDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
