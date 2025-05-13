namespace Entities.DTOs.CMMDto
{
    public abstract record CMMDtoForManipulation
    {
        public ICollection<string>? Files { get; set; }
        public ICollection<string>? ResultFiles { get; set; }
        public string? ProjectName { get; init; }
        public string? PartCode { get; init; }
        public string? Stand { get; init; }
        public int? Time { get; init; }
        public DateTime? Date { get; set; }
        public DateTime? InstallResultDate { get; set; }
        public string? SolidModel { get; init; }
        public string? Description { get; init; }
        public string? MeasuringPersonID { get; init; }
        public string? CMMUserID { get; init; }
        public string? ResponibleID { get; init; }
        public string? PersonInChargeID { get; init; }
        public string? QualityOfficerID { get; init; }
        public string? UserId { get; init; }
    }
}
