namespace Entities.DTOs.AssemblySuccessStateDto
{
    public record AssemblySuccessStateDtoForInsertion : AssemblySuccessStateDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
