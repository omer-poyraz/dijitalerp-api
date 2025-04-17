using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAssemblyNoteRepository : IRepositoryBase<AssemblyNote>
    {
        Task<IEnumerable<AssemblyNote>> GetAllAssemblyNoteAsync(bool? trackChanges);
        Task<AssemblyNote> GetAssemblyNoteByIdAsync(int id, bool? trackChanges);
        AssemblyNote CreateAssemblyNote(AssemblyNote assemblyNote);
        AssemblyNote UpdateAssemblyNote(AssemblyNote assemblyNote);
        AssemblyNote DeleteAssemblyNote(AssemblyNote assemblyNote);
    }
}
