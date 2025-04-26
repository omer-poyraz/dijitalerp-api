using Entities.DTOs.TechnicalDrawingDto;

namespace Services.Contracts
{
    public interface ITechnicalDrawingService
    {
        Task<IEnumerable<TechnicalDrawingDto>> GetAllTechnicalDrawingAsync(bool? trackChanges);
        Task<TechnicalDrawingDto> GetTechnicalDrawingByIdAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingDto> CreateTechnicalDrawingAsync(TechnicalDrawingDtoForInsertion technicalDrawingDtoForInsertion);
        Task<TechnicalDrawingDto> UpdateTechnicalDrawingAsync(TechnicalDrawingDtoForUpdate technicalDrawingDtoForUpdate);
        Task<TechnicalDrawingDto> AddFileTechnicalDrawingAsync(TechnicalDrawingDtoForAddFile technicalDrawingDtoForAddFile);
        Task<TechnicalDrawingDto> DeleteTechnicalDrawingAsync(int id, bool? trackChanges);
    }
}
