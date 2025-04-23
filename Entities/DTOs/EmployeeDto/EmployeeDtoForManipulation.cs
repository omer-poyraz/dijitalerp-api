namespace Entities.DTOs.EmployeeDto
{
    public abstract record EmployeeDtoForManipulation
    {
        public string? File { get; set; }
        public string? Name { get; init; }
        public string? Surname { get; init; }
        public string? Email { get; init; }
        public string? Phone { get; init; }
        public string? Address { get; init; }
        public string? Field { get; init; }
        public DateTime? Birthday { get; set; }
        public DateTime? StartDate { get; set; }
        public string? UserId { get; init; }
    }
}
