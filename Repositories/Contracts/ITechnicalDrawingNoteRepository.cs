using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITechnicalDrawingNoteRepository : IRepositoryBase<TechnicalDrawingNote>
    {
        Task<IEnumerable<TechnicalDrawingNote>> GetAllTechnicalDrawingNoteAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingNote>> GetAllTechnicalDrawingNoteByDrawingAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingNote> GetTechnicalDrawingNoteByIdAsync(int id, bool? trackChanges);
        TechnicalDrawingNote CreateTechnicalDrawingNote(TechnicalDrawingNote technicalDrawingNote);
        TechnicalDrawingNote UpdateTechnicalDrawingNote(TechnicalDrawingNote technicalDrawingNote);
        TechnicalDrawingNote DeleteTechnicalDrawingNote(TechnicalDrawingNote technicalDrawingNote);
    }
}
