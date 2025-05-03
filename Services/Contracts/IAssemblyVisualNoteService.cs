using Entities.DTOs.AssemblyVisualNoteDto;

namespace Services.Contracts
{
    public interface IAssemblyVisualNoteService
    {
        Task<IEnumerable<AssemblyVisualNoteDto>> GetAllAssemblyVisualNoteAsync(bool? trackChanges);
        Task<IEnumerable<AssemblyVisualNoteDto>> GetAllAssemblyVisualNoteByDrawingAsync(int id, bool? trackChanges);
        Task<AssemblyVisualNoteDto> GetAssemblyVisualNoteByIdAsync(int id, bool? trackChanges);
        Task<AssemblyVisualNoteDto> CreateAssemblyVisualNoteAsync(AssemblyVisualNoteDtoForInsertion assemblyVisualNoteDtoForInsertion);
        Task<AssemblyVisualNoteDto> DeleteAssemblyVisualNoteAsync(int id, bool? trackChanges);
    }
}
