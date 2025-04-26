using Entities.DTOs.TechnicalDrawingNoteDto;

namespace Services.Contracts
{
    public interface ITechnicalDrawingNoteService
    {
        Task<IEnumerable<TechnicalDrawingNoteDto>> GetAllTechnicalDrawingNoteAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingNoteDto>> GetAllTechnicalDrawingNoteByDrawingAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingNoteDto> GetTechnicalDrawingNoteByIdAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingNoteDto> CreateTechnicalDrawingNoteAsync(TechnicalDrawingNoteDtoForInsertion technicalDrawingNoteDtoForInsertion);
        Task<TechnicalDrawingNoteDto> UpdateTechnicalDrawingNoteAsync(TechnicalDrawingNoteDtoForUpdate technicalDrawingNoteDtoForUpdate);
        Task<TechnicalDrawingNoteDto> DeleteTechnicalDrawingNoteAsync(int id, bool? trackChanges);
    }
}
