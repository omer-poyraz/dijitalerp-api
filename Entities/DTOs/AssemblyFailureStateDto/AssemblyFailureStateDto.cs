using Entities.Models;

namespace Entities.DTOs.AssemblyFailureStateDto
{
    public class AssemblyFailureStateDto
    {
        public int ID { get; init; }
        public string? Inappropriateness { get; init; }
        public Employee? Technician { get; init; }
        public int? TechnicianID { get; init; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public int? PendingQuantity { get; init; }
        public string? QualityDescription { get; init; }
        public DateTime? Date { get; init; }
        public AssemblyManuel? AssemblyManuel { get; init; }
        public int AssemblyManuelID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
