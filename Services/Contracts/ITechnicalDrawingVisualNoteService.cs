using Entities.DTOs.TechnicalDrawingVisualNoteDto;

namespace Services.Contracts
{
    public interface ITechnicalDrawingVisualNoteService
    {
        Task<IEnumerable<TechnicalDrawingVisualNoteDto>> GetAllTechnicalDrawingVisualNoteAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingVisualNoteDto>> GetAllTechnicalDrawingVisualNoteByDrawingAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingVisualNoteDto> GetTechnicalDrawingVisualNoteByIdAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingVisualNoteDto> CreateTechnicalDrawingVisualNoteAsync(TechnicalDrawingVisualNoteDtoForInsertion technicalDrawingVisualNoteDtoForInsertion);
        Task<TechnicalDrawingVisualNoteDto> DeleteTechnicalDrawingVisualNoteAsync(int id, bool? trackChanges);
    }
}
