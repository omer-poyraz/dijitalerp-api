using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.EmployeeDto
{
    public record EmployeeDtoForUpdate : EmployeeDtoForManipulation
    {
        public int ID { get; init; }
        public IFormFile? file { get; set; }
        public bool? TrackChanges { get; init; } = false;
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
