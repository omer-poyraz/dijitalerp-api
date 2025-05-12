using Entities.Models;

namespace Entities.DTOs.CMMSuccessStateDto
{
    public class CMMSuccessStateDto
    {
        public int ID { get; init; }
        public string? Description { get; init; }
        public User? Technician { get; init; }
        public string? TechnicianID { get; init; }
        public string? PartCode { get; init; }
        public bool? Status { get; init; }
        public string? Approval { get; init; }
        public int? PendingQuantity { get; init; }
        public string? QualityDescription { get; init; }
        public DateTime? Date { get; init; }
        public CMM? CMM { get; init; }
        public int? CMMID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
