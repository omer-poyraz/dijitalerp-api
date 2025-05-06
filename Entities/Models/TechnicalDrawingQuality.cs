using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class TechnicalDrawingQuality
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        [ForeignKey("TechnicalDrawingFailureStateID")]
        public TechnicalDrawingFailureState? TechnicalDrawingFailureState { get; set; }
        public int? TechnicalDrawingFailureStateID { get; set; }
        public User? QualityOfficer { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}