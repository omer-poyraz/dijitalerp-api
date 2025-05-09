using Entities.Models;

namespace Entities.DTOs.AssemblyFailureStateDto
{
    public class AssemblyFailureStateDto
    {
        public int ID { get; init; }
        public string? Inappropriateness { get; init; }
        public string? Description { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; init; }
        public User? Technician { get; init; }
        public string? TechnicianID { get; init; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public int? PendingQuantity { get; init; }
        public User? QualityOfficer { get; init; }
        public string? QualityOfficerID { get; init; }
        public ICollection<AssemblyQuality>? QualityOfficerDescriptions { get; init; }
        public DateTime? Date { get; init; }
        public AssemblyManuel? AssemblyManuel { get; init; }
        public int AssemblyManuelID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
