namespace Entities.DTOs.AssemblyFailureStateDto
{
    public record AssemblyFailureStateDtoForInsertion : AssemblyFailureStateDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
