using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class TechnicalDrawing
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public string? ProjectName { get; set; }
        public string? PartCode { get; set; }
        public string? Stand { get; set; }
        [ForeignKey("ResponibleID")]
        public Employee? Responible { get; set; }
        public int? ResponibleID { get; set; }
        [ForeignKey("PersonInChargeID")]
        public Employee? PersonInCharge { get; set; }
        public int? PersonInChargeID { get; set; }
        public string? SerialNumber { get; set; }
        public int? ProductionQuantity { get; set; }
        public int? Time { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public DateTime? OperatorDate { get; set; }
        public ICollection<TechnicalDrawingNote>? TechnicalDrawingNotes { get; set; }
        public ICollection<TechnicalDrawingSuccessState>? BasariliDurumlar { get; set; }
        public ICollection<TechnicalDrawingFailureState>? BasarisizDurumlar { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
