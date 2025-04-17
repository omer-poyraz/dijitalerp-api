namespace Entities.DTOs.AssemblyNoteDto
{
    public abstract record AssemblyNoteDtoForManipulation
    {
        public string? Note { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public int AssemblyManuelID { get; init; }
        public string? UserId { get; init; }
    }
}
