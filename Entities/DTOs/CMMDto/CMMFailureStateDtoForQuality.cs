namespace Entities.DTOs.CMMFailureStateDto
{
    public class CMMFailureStateDtoForQuality
    {
        public int ID { get; init; }
        public string? QualityOfficerID { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; set; }
    }
}
