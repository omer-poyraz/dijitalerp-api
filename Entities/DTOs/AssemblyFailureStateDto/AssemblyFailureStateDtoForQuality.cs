namespace Entities.DTOs.AssemblyFailureStateDto
{
    public class AssemblyFailureStateDtoForQuality
    {
        public int ID { get; init; }
        public string? QualityOfficerID { get; init; }
        public string? QualityOfficerDescription { get; init; }
        public DateTime? QualityDescriptionDate { get; set; }
    }
}
