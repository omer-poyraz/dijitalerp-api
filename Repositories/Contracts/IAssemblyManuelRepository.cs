using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAssemblyManuelRepository : IRepositoryBase<AssemblyManuel>
    {
        Task<IEnumerable<AssemblyManuel>> GetAllAssemblyManuelAsync(bool? trackChanges);
        Task<AssemblyManuel> GetAssemblyManuelByIdAsync(int id, bool? trackChanges);
        AssemblyManuel CreateAssemblyManuel(AssemblyManuel assemblyManuel);
        AssemblyManuel UpdateAssemblyManuel(AssemblyManuel assemblyManuel);
        AssemblyManuel DeleteAssemblyManuel(AssemblyManuel assemblyManuel);
    }
}
