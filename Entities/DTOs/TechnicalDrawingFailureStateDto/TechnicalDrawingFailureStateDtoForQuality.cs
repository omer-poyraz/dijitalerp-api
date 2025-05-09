namespace Entities.DTOs.TechnicalDrawingFailureStateDto
{
    public class TechnicalDrawingFailureStateDtoForQuality
    {
        public int ID { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public string? QualityOfficerID { get; init; }
        public DateTime? QualityDescriptionDate { get; set; }
    }
}
