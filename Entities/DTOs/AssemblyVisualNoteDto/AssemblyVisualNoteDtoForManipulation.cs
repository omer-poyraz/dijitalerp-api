namespace Entities.DTOs.AssemblyVisualNoteDto
{
    public abstract record AssemblyVisualNoteDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public string? Note { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public int AssemblyManuelID { get; init; }
        public string? UserId { get; init; }
    }
}
