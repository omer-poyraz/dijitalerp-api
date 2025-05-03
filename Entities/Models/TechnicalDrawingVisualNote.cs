using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class TechnicalDrawingVisualNote
    {
        public int ID { get; set; }
        public ICollection<string>? Files { get; set; }
        public string? Note { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("TechnicalDrawingID")]
        public TechnicalDrawing? TechnicalDrawing { get; set; }
        public int TechnicalDrawingID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
