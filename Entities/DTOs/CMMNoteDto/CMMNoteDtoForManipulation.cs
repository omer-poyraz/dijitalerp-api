namespace Entities.DTOs.CMMNoteDto
{
    public abstract record CMMNoteDtoForManipulation
    {
        public string? Note { get; init; }
        public string? PartCode { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public int CMMID { get; init; }
        public string? UserId { get; init; }
    }
}
