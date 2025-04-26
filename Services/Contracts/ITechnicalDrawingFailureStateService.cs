using Entities.DTOs.TechnicalDrawingFailureStateDto;

namespace Services.Contracts
{
    public interface ITechnicalDrawingFailureStateService
    {
        Task<IEnumerable<TechnicalDrawingFailureStateDto>> GetAllTechnicalDrawingFailureStateAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingFailureStateDto>> GetAllTechnicalDrawingFailureStateByDrawingAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingFailureStateDto> GetTechnicalDrawingFailureStateByIdAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingFailureStateDto> CreateTechnicalDrawingFailureStateAsync(TechnicalDrawingFailureStateDtoForInsertion technicalDrawingFailureStateDtoForInsertion);
        Task<TechnicalDrawingFailureStateDto> UpdateTechnicalDrawingFailureStateAsync(TechnicalDrawingFailureStateDtoForUpdate technicalDrawingFailureStateDtoForUpdate);
        Task<TechnicalDrawingFailureStateDto> DeleteTechnicalDrawingFailureStateAsync(int id, bool? trackChanges);
    }
}
