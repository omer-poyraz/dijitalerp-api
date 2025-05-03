using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITechnicalDrawingVisualNoteRepository : IRepositoryBase<TechnicalDrawingVisualNote>
    {
        Task<IEnumerable<TechnicalDrawingVisualNote>> GetAllTechnicalDrawingVisualNoteAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingVisualNote>> GetAllTechnicalDrawingVisualNoteByDrawingAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingVisualNote> GetTechnicalDrawingVisualNoteByIdAsync(int id, bool? trackChanges);
        TechnicalDrawingVisualNote CreateTechnicalDrawingVisualNote(TechnicalDrawingVisualNote technicalDrawingVisualNote);
        TechnicalDrawingVisualNote DeleteTechnicalDrawingVisualNote(TechnicalDrawingVisualNote technicalDrawingVisualNote);
    }
}
