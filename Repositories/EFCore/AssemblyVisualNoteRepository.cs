using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class AssemblyVisualNoteRepository : RepositoryBase<AssemblyVisualNote>, IAssemblyVisualNoteRepository
    {
        public AssemblyVisualNoteRepository(RepositoryContext context) : base(context) { }

        public AssemblyVisualNote CreateAssemblyVisualNote(AssemblyVisualNote assemblyVisualNote)
        {
            Create(assemblyVisualNote);
            return assemblyVisualNote;
        }

        public AssemblyVisualNote DeleteAssemblyVisualNote(AssemblyVisualNote assemblyVisualNote)
        {
            Delete(assemblyVisualNote);
            return assemblyVisualNote;
        }

        public async Task<IEnumerable<AssemblyVisualNote>> GetAllAssemblyVisualNoteAsync(bool? trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<IEnumerable<AssemblyVisualNote>> GetAllAssemblyVisualNoteByDrawingAsync(int id, bool? trackChanges) =>
            await FindAll(trackChanges)
                .Where(s => s.AssemblyManuelID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<IEnumerable<AssemblyVisualNote>> GetAllAssemblyVisualNoteByManualAsync(int id, bool? trackChanges) =>
            await FindAll(trackChanges)
                .Where(s => s.AssemblyManuelID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<AssemblyVisualNote> GetAssemblyVisualNoteByIdAsync(int id, bool? trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public AssemblyVisualNote UpdateAssemblyVisualNote(AssemblyVisualNote assemblyVisualNote)
        {
            Update(assemblyVisualNote);
            return assemblyVisualNote;
        }
    }
}
