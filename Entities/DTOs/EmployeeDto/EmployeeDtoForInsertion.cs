using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.EmployeeDto
{
    public record EmployeeDtoForInsertion : EmployeeDtoForManipulation
    {
        public IFormFile? file { get; set; }
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
