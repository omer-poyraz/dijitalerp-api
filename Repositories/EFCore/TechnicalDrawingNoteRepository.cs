using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TechnicalDrawingNoteRepository : RepositoryBase<TechnicalDrawingNote>, ITechnicalDrawingNoteRepository
    {
        public TechnicalDrawingNoteRepository(RepositoryContext context) : base(context) { }

        public TechnicalDrawingNote CreateTechnicalDrawingNote(TechnicalDrawingNote technicalDrawingNote)
        {
            Create(technicalDrawingNote);
            return technicalDrawingNote;
        }

        public TechnicalDrawingNote DeleteTechnicalDrawingNote(TechnicalDrawingNote technicalDrawingNote)
        {
            Delete(technicalDrawingNote);
            return technicalDrawingNote;
        }

        public async Task<IEnumerable<TechnicalDrawingNote>> GetAllTechnicalDrawingNoteAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();
        }

        public async Task<IEnumerable<TechnicalDrawingNote>> GetAllTechnicalDrawingNoteByDrawingAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.TechnicalDrawingID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<TechnicalDrawingNote> GetTechnicalDrawingNoteByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public TechnicalDrawingNote UpdateTechnicalDrawingNote(TechnicalDrawingNote technicalDrawingNote)
        {
            Update(technicalDrawingNote);
            return technicalDrawingNote;
        }
    }
}
