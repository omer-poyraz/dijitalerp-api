using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class AssemblySuccessStateRepository : RepositoryBase<AssemblySuccessState>, IAssemblySuccessStateRepository
    {
        public AssemblySuccessStateRepository(RepositoryContext context) : base(context) { }

        public AssemblySuccessState CreateAssemblySuccessState(AssemblySuccessState assemblySuccessState)
        {
            Create(assemblySuccessState);
            return assemblySuccessState;
        }

        public AssemblySuccessState DeleteAssemblySuccessState(AssemblySuccessState assemblySuccessState)
        {
            Delete(assemblySuccessState);
            return assemblySuccessState;
        }

        public async Task<IEnumerable<AssemblySuccessState>> GetAllAssemblySuccessStateAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<AssemblySuccessState>> GetAllAssemblySuccessStateByManualAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.AssemblyManuelID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<AssemblySuccessState> GetAssemblySuccessStateByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public AssemblySuccessState UpdateAssemblySuccessState(AssemblySuccessState assemblySuccessState)
        {
            Update(assemblySuccessState);
            return assemblySuccessState;
        }
    }
}
