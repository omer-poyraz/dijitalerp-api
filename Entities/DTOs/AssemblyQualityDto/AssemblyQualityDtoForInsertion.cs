namespace Entities.DTOs.AssemblyQualityDto
{
    public record AssemblyQualityDtoForInsertion : AssemblyQualityDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
