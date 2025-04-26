using Entities.DTOs.TechnicalDrawingSuccessStateDto;

namespace Services.Contracts
{
    public interface ITechnicalDrawingSuccessStateService
    {
        Task<IEnumerable<TechnicalDrawingSuccessStateDto>> GetAllTechnicalDrawingSuccessStateAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingSuccessStateDto>> GetAllTechnicalDrawingSuccessStateByDrawingAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingSuccessStateDto> GetTechnicalDrawingSuccessStateByIdAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingSuccessStateDto> CreateTechnicalDrawingSuccessStateAsync(TechnicalDrawingSuccessStateDtoForInsertion technicalDrawingSuccessStateDtoForInsertion);
        Task<TechnicalDrawingSuccessStateDto> UpdateTechnicalDrawingSuccessStateAsync(TechnicalDrawingSuccessStateDtoForUpdate technicalDrawingSuccessStateDtoForUpdate);
        Task<TechnicalDrawingSuccessStateDto> DeleteTechnicalDrawingSuccessStateAsync(int id, bool? trackChanges);
    }
}
