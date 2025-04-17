namespace Entities.DTOs.DepartmentDto
{
    public abstract record DepartmentDtoForManipulation
    {
        public string? Name { get; init; }
        public string? UserId { get; init; }
    }
}
