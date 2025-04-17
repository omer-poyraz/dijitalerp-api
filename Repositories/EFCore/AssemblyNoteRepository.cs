using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class AssemblyNoteRepository : RepositoryBase<AssemblyNote>, IAssemblyNoteRepository
    {
        public AssemblyNoteRepository(RepositoryContext context) : base(context) { }

        public AssemblyNote CreateAssemblyNote(AssemblyNote assemblyNote)
        {
            Create(assemblyNote);
            return assemblyNote;
        }

        public AssemblyNote DeleteAssemblyNote(AssemblyNote assemblyNote)
        {
            Delete(assemblyNote);
            return assemblyNote;
        }

        public async Task<IEnumerable<AssemblyNote>> GetAllAssemblyNoteAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();
        }

        public async Task<AssemblyNote> GetAssemblyNoteByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public AssemblyNote UpdateAssemblyNote(AssemblyNote assemblyNote)
        {
            Update(assemblyNote);
            return assemblyNote;
        }
    }
}
