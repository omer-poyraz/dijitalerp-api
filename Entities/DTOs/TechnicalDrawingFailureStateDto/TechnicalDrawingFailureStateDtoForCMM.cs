namespace Entities.DTOs.TechnicalDrawingFailureStateDto
{
    public class TechnicalDrawingFailureStateDtoForCMM
    {
        public int ID { get; init; }
        public string? CMMID { get; init; }
        public string? CMMDescription { get; init; }
        public DateTime? CMMDescriptionDate { get; set; }
    }
}
