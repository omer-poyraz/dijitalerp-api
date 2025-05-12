using Entities.Models;

namespace Entities.DTOs.CMMFailureStateDto
{
    public class CMMFailureStateDto
    {
        public int ID { get; init; }
        public string? Inappropriateness { get; init; }
        public User? Technician { get; init; }
        public string? TechnicianID { get; init; }
        public string? Description { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; init; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public int? PendingQuantity { get; init; }
        public int? Total { get; init; }
        public DateTime? Date { get; init; }
        public CMM? CMM { get; init; }
        public int CMMID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
