using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICMMNoteRepository : IRepositoryBase<CMMNote>
    {
        Task<IEnumerable<CMMNote>> GetAllCMMNoteAsync(bool? trackChanges);
        Task<IEnumerable<CMMNote>> GetAllCMMNoteByManualAsync(int id, bool? trackChanges);
        Task<CMMNote> GetCMMNoteByIdAsync(int id, bool? trackChanges);
        CMMNote CreateCMMNote(CMMNote cmmNote);
        CMMNote UpdateCMMNote(CMMNote cmmNote);
        CMMNote DeleteCMMNote(CMMNote cmmNote);
    }
}
