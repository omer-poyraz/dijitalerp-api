namespace Entities.DTOs.DepartmentDto
{
    public record DepartmentDtoForInsertion : DepartmentDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
