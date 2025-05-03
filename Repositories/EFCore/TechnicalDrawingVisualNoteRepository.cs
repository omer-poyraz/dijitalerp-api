using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TechnicalDrawingVisualNoteRepository : RepositoryBase<TechnicalDrawingVisualNote>, ITechnicalDrawingVisualNoteRepository
    {
        public TechnicalDrawingVisualNoteRepository(RepositoryContext context) : base(context) { }

        public TechnicalDrawingVisualNote CreateTechnicalDrawingVisualNote(TechnicalDrawingVisualNote technicalDrawingVisualNote)
        {
            Create(technicalDrawingVisualNote);
            return technicalDrawingVisualNote;
        }

        public TechnicalDrawingVisualNote DeleteTechnicalDrawingVisualNote(TechnicalDrawingVisualNote technicalDrawingVisualNote)
        {
            Delete(technicalDrawingVisualNote);
            return technicalDrawingVisualNote;
        }

        public async Task<IEnumerable<TechnicalDrawingVisualNote>> GetAllTechnicalDrawingVisualNoteAsync(bool? trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<IEnumerable<TechnicalDrawingVisualNote>> GetAllTechnicalDrawingVisualNoteByDrawingAsync(int id, bool? trackChanges) =>
            await FindAll(trackChanges)
                .Where(s => s.TechnicalDrawingID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<TechnicalDrawingVisualNote> GetTechnicalDrawingVisualNoteByIdAsync(int id, bool? trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();


        public TechnicalDrawingVisualNote UpdateTechnicalDrawingVisualNote(TechnicalDrawingVisualNote technicalDrawingVisualNote)
        {
            Update(technicalDrawingVisualNote);
            return technicalDrawingVisualNote;
        }
    }
}
