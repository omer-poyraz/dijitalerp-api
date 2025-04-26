using Entities.Models;

namespace Entities.DTOs.TechnicalDrawingSuccessStateDto
{
    public class TechnicalDrawingSuccessStateDto
    {
        public int ID { get; init; }
        public string? ProjectName { get; init; }
        public string? Stand { get; init; }
        public string? PartCode { get; init; }
        public string? Description { get; init; }
        public int? ProductionQuantity { get; init; }
        public string? QuantityDescription { get; init; }
        public string? Approval { get; init; }
        public bool? Status { get; init; }
        public DateTime? Date { get; init; }
        public Employee? Operator { get; init; }
        public int? OperatorID { get; init; }
        public TechnicalDrawing? TechnicalDrawing { get; init; }
        public int? TechnicalDrawingID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
