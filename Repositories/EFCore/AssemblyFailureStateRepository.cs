using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class AssemblyFailureStateRepository : RepositoryBase<AssemblyFailureState>, IAssemblyFailureStateRepository
    {
        public AssemblyFailureStateRepository(RepositoryContext context) : base(context) { }

        public AssemblyFailureState CreateAssemblyFailureState(AssemblyFailureState assemblyFailureState)
        {
            Create(assemblyFailureState);
            return assemblyFailureState;
        }

        public AssemblyFailureState DeleteAssemblyFailureState(AssemblyFailureState assemblyFailureState)
        {
            Delete(assemblyFailureState);
            return assemblyFailureState;
        }

        public async Task<IEnumerable<AssemblyFailureState>> GetAllAssemblyFailureStateAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<AssemblyFailureState>> GetAllAssemblyFailureStateByManualAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.AssemblyManuelID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<AssemblyFailureState> GetAssemblyFailureStateByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public AssemblyFailureState UpdateAssemblyFailureByQualityState(AssemblyFailureState assemblyFailureState)
        {
            Update(assemblyFailureState);
            return assemblyFailureState;
        }

        public AssemblyFailureState UpdateAssemblyFailureState(AssemblyFailureState assemblyFailureState)
        {
            Update(assemblyFailureState);
            return assemblyFailureState;
        }
    }
}
