using Entities.DTOs.AssemblyNoteDto;

namespace Services.Contracts
{
    public interface IAssemblyNoteService
    {
        Task<IEnumerable<AssemblyNoteDto>> GetAllAssemblyNoteAsync(bool? trackChanges);
        Task<IEnumerable<AssemblyNoteDto>> GetAllAssemblyNoteByManualAsync(int id, bool? trackChanges);
        Task<AssemblyNoteDto> GetAssemblyNoteByIdAsync(int id, bool? trackChanges);
        Task<AssemblyNoteDto> CreateAssemblyNoteAsync(AssemblyNoteDtoForInsertion assemblyNoteDtoForInsertion);
        Task<AssemblyNoteDto> UpdateAssemblyNoteAsync(AssemblyNoteDtoForUpdate assemblyNoteDtoForUpdate);
        Task<AssemblyNoteDto> DeleteAssemblyNoteAsync(int id, bool? trackChanges);
    }
}
