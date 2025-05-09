using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAssemblyFailureStateRepository : IRepositoryBase<AssemblyFailureState>
    {
        Task<IEnumerable<AssemblyFailureState>> GetAllAssemblyFailureStateAsync(bool? trackChanges);
        Task<IEnumerable<AssemblyFailureState>> GetAllAssemblyFailureStateByManualAsync(int id, bool? trackChanges);
        Task<AssemblyFailureState> GetAssemblyFailureStateByIdAsync(int id, bool? trackChanges);
        AssemblyFailureState CreateAssemblyFailureState(AssemblyFailureState assemblyFailureState);
        AssemblyFailureState UpdateAssemblyFailureState(AssemblyFailureState assemblyFailureState);
        AssemblyFailureState UpdateAssemblyFailureByQualityState(AssemblyFailureState assemblyFailureState);
        AssemblyFailureState DeleteAssemblyFailureState(AssemblyFailureState assemblyFailureState);
    }
}
