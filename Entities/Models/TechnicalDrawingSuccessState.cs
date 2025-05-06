using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class TechnicalDrawingSuccessState
    {
        public int ID { get; set; }
        public string? ProjectName { get; set; }
        public string? Stand { get; set; }
        public string? PartCode { get; set; }
        public string? Description { get; set; }
        public int? ProductionQuantity { get; set; }
        public string? QuantityDescription { get; set; }
        public string? Approval { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }

        [ForeignKey("OperatorID")]
        public User? Operator { get; set; }
        public string? OperatorID { get; set; }
        [ForeignKey("TechnicalDrawingID")]
        public TechnicalDrawing? TechnicalDrawing { get; set; }
        public int? TechnicalDrawingID { get; set; }

        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
