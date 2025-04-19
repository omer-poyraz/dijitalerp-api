using Entities.DTOs.AssemblyFailureStateDto;

namespace Services.Contracts
{
    public interface IAssemblyFailureStateService
    {
        Task<IEnumerable<AssemblyFailureStateDto>> GetAllAssemblyFailureStateAsync(bool? trackChanges);
        Task<IEnumerable<AssemblyFailureStateDto>> GetAllAssemblyFailureStateByManualAsync(int id, bool? trackChanges);
        Task<AssemblyFailureStateDto> GetAssemblyFailureStateByIdAsync(int id, bool? trackChanges);
        Task<AssemblyFailureStateDto> CreateAssemblyFailureStateAsync(AssemblyFailureStateDtoForInsertion assemblyFailureStateDtoForInsertion);
        Task<AssemblyFailureStateDto> UpdateAssemblyFailureStateAsync(AssemblyFailureStateDtoForUpdate assemblyFailureStateDtoForUpdate);
        Task<AssemblyFailureStateDto> DeleteAssemblyFailureStateAsync(int id, bool? trackChanges);
    }
}
