using Entities.Models;

namespace Entities.DTOs.AssemblySuccessStateDto
{
    public class AssemblySuccessStateDto
    {
        public int ID { get; init; }
        public string? Description { get; init; }
        public Employee? Technician { get; init; }
        public int? TechnicianID { get; init; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public string? Approval { get; init; }
        public int? PendingQuantity { get; init; }
        public string? QualityDescription { get; init; }
        public DateTime? Date { get; init; }
        public AssemblyManuel? AssemblyProject { get; init; }
        public int? AssemblyManuelID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
