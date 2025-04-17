using Entities.DTOs.AssemblySuccessStateDto;

namespace Services.Contracts
{
    public interface IAssemblySuccessStateService
    {
        Task<IEnumerable<AssemblySuccessStateDto>> GetAllAssemblySuccessStateAsync(bool? trackChanges);
        Task<AssemblySuccessStateDto> GetAssemblySuccessStateByIdAsync(int id, bool? trackChanges);
        Task<AssemblySuccessStateDto> CreateAssemblySuccessStateAsync(AssemblySuccessStateDtoForInsertion assemblySuccessStateDtoForInsertion);
        Task<AssemblySuccessStateDto> UpdateAssemblySuccessStateAsync(AssemblySuccessStateDtoForUpdate assemblySuccessStateDtoForUpdate);
        Task<AssemblySuccessStateDto> DeleteAssemblySuccessStateAsync(int id, bool? trackChanges);
    }
}
