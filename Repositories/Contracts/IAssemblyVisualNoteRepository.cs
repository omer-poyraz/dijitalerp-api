using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAssemblyVisualNoteRepository : IRepositoryBase<AssemblyVisualNote>
    {
        Task<IEnumerable<AssemblyVisualNote>> GetAllAssemblyVisualNoteAsync(bool? trackChanges);
        Task<IEnumerable<AssemblyVisualNote>> GetAllAssemblyVisualNoteByDrawingAsync(int id, bool? trackChanges);
        Task<AssemblyVisualNote> GetAssemblyVisualNoteByIdAsync(int id, bool? trackChanges);
        AssemblyVisualNote CreateAssemblyVisualNote(AssemblyVisualNote assemblyVisualNote);
        AssemblyVisualNote UpdateAssemblyVisualNote(AssemblyVisualNote assemblyVisualNote);
        AssemblyVisualNote DeleteAssemblyVisualNote(AssemblyVisualNote assemblyVisualNote);
    }
}
