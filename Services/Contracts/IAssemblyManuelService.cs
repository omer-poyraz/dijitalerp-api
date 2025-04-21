using Entities.DTOs.AssemblyManuelDto;

namespace Services.Contracts
{
    public interface IAssemblyManuelService
    {
        Task<IEnumerable<AssemblyManuelDto>> GetAllAssemblyManuelAsync(bool? trackChanges);
        Task<AssemblyManuelDto> GetAssemblyManuelByIdAsync(int id, bool? trackChanges);
        Task<AssemblyManuelDto> CreateAssemblyManuelAsync(AssemblyManuelDtoForInsertion assemblyManuelDtoForInsertion);
        Task<AssemblyManuelDto> UpdateAssemblyManuelAsync(AssemblyManuelDtoForUpdate assemblyManuelDtoForUpdate);
        Task<AssemblyManuelDto> AddFileAssemblyManuelAsync(AssemblyManuelDtoForAddFile assemblyManuelDtoForAddFile);
        Task<AssemblyManuelDto> DeleteAssemblyManuelAsync(int id, bool? trackChanges);
    }
}
