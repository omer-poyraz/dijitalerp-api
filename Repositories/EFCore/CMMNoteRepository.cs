using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CMMNoteRepository : RepositoryBase<CMMNote>, ICMMNoteRepository
    {
        public CMMNoteRepository(RepositoryContext context) : base(context) { }

        public CMMNote CreateCMMNote(CMMNote cmmNote)
        {
            Create(cmmNote);
            return cmmNote;
        }

        public CMMNote DeleteCMMNote(CMMNote cmmNote)
        {
            Delete(cmmNote);
            return cmmNote;
        }

        public async Task<IEnumerable<CMMNote>> GetAllCMMNoteAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();
        }

        public async Task<IEnumerable<CMMNote>> GetAllCMMNoteByManualAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.CMMID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<CMMNote> GetCMMNoteByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public CMMNote UpdateCMMNote(CMMNote cmmNote)
        {
            Update(cmmNote);
            return cmmNote;
        }
    }
}
