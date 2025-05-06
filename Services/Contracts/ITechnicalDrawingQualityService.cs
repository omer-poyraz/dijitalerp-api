using Entities.DTOs.TechnicalDrawingQualityDto;

namespace Services.Contracts
{
    public interface ITechnicalDrawingQualityService
    {
        Task<IEnumerable<TechnicalDrawingQualityDto>> GetAllTechnicalDrawingQualityAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingQualityDto>> GetAllTechnicalDrawingQualityByFailureAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingQualityDto> GetTechnicalDrawingQualityByIdAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingQualityDto> CreateTechnicalDrawingQualityAsync(TechnicalDrawingQualityDtoForInsertion technicalDrawingQualityDtoForInsertion);
        Task<TechnicalDrawingQualityDto> UpdateTechnicalDrawingQualityAsync(TechnicalDrawingQualityDtoForUpdate technicalDrawingQualityDtoForUpdate);
        Task<TechnicalDrawingQualityDto> DeleteTechnicalDrawingQualityAsync(int id, bool? trackChanges);
    }
}
