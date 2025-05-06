namespace Entities.DTOs.AssemblyQualityDto
{
    public abstract record AssemblyQualityDtoForManipulation
    {
        public string? Description { get; init; }
        public string? Note { get; init; }
        public int? AssemblyFailureStateID { get; init; }
        public string? UserId { get; init; }
    }
}
