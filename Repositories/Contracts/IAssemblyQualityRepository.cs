using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAssemblyQualityRepository : IRepositoryBase<AssemblyQuality>
    {
        Task<IEnumerable<AssemblyQuality>> GetAllAssemblyQualityAsync(bool? trackChanges);
        Task<IEnumerable<AssemblyQuality>> GetAllAssemblyQualityByFailureAsync(int id, bool? trackChanges);
        Task<AssemblyQuality> GetAssemblyQualityByIdAsync(int id, bool? trackChanges);
        AssemblyQuality CreateAssemblyQuality(AssemblyQuality assemblyQuality);
        AssemblyQuality UpdateAssemblyQuality(AssemblyQuality assemblyQuality);
        AssemblyQuality DeleteAssemblyQuality(AssemblyQuality assemblyQuality);
    }
}
