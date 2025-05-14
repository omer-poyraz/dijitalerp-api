using Entities.Models;

namespace Entities.DTOs.TechnicalDrawingFailureStateDto
{
    public class TechnicalDrawingFailureStateDto
    {
        public int ID { get; init; }
        public string? Inappropriateness { get; init; }
        public string? ProjectName { get; init; }
        public string? Stand { get; init; }
        public string? PartCode { get; init; }
        public string? Description { get; init; }
        public int? ProductionQuantity { get; init; }
        public string? Approval { get; init; }
        public bool? Status { get; init; }
        public DateTime? Date { get; init; }
        public User? Operator { get; init; }
        public string? OperatorID { get; init; }
        public User? QualityOfficer { get; init; }
        public string? QualityOfficerID { get; init; }
        public User? CMMUser { get; init; }
        public string? CMMUserID { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public string? CMMDescription { get; init; }
        public DateTime? CMMDescriptionDate { get; set; }
        public DateTime? QualityDescriptionDate { get; init; }
        public ICollection<TechnicalDrawingQuality>? QualityOfficerDescriptions { get; init; }
        public TechnicalDrawing? TechnicalDrawing { get; init; }
        public int? TechnicalDrawingID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
