using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAssemblySuccessStateRepository : IRepositoryBase<AssemblySuccessState>
    {
        Task<IEnumerable<AssemblySuccessState>> GetAllAssemblySuccessStateAsync(bool? trackChanges);
        Task<IEnumerable<AssemblySuccessState>> GetAllAssemblySuccessStateByManualAsync(int id, bool? trackChanges);
        Task<AssemblySuccessState> GetAssemblySuccessStateByIdAsync(int id, bool? trackChanges);
        AssemblySuccessState CreateAssemblySuccessState(AssemblySuccessState assemblySuccessState);
        AssemblySuccessState UpdateAssemblySuccessState(AssemblySuccessState assemblySuccessState);
        AssemblySuccessState DeleteAssemblySuccessState(AssemblySuccessState assemblySuccessState);
    }
}
