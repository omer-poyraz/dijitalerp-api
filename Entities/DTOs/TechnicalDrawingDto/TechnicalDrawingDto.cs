using Entities.Models;

namespace Entities.DTOs.TechnicalDrawingDto
{
    public class TechnicalDrawingDto
    {
        public int ID { get; init; }
        public ICollection<string>? Files { get; init; }
        public string? ProjectName { get; init; }
        public string? PartCode { get; init; }
        public string? Stand { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; init; }
        public User? Responible { get; init; }
        public string? ResponibleID { get; init; }
        public User? PersonInCharge { get; init; }
        public string? PersonInChargeID { get; init; }
        public string? SerialNumber { get; init; }
        public int? ProductionQuantity { get; init; }
        public User? QualityOfficer { get; init; }
        public string? QualityOfficerID { get; init; }
        public int? Time { get; init; }
        public DateTime? Date { get; init; }
        public string? Description { get; init; }
        public DateTime? OperatorDate { get; init; }
        public ICollection<TechnicalDrawingNote>? TechnicalDrawingNotes { get; init; }
        public ICollection<TechnicalDrawingSuccessState>? BasariliDurumlar { get; init; }
        public ICollection<TechnicalDrawingFailureState>? BasarisizDurumlar { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
