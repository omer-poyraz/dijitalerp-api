using Entities.Models;

namespace Entities.DTOs.TechnicalDrawingQualityDto
{
    public class TechnicalDrawingQualityDto
    {
        public int ID { get; init; }
        public string? Description { get; init; }
        public string? Note { get; init; }
        public TechnicalDrawingFailureState? TechnicalDrawingFailureState { get; init; }
        public int? TechnicalDrawingFailureStateID { get; init; }
        public User? QualityOfficer { get; init; }
        public string? UserId { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
