using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class AssemblyQualityRepository : RepositoryBase<AssemblyQuality>, IAssemblyQualityRepository
    {
        public AssemblyQualityRepository(RepositoryContext context) : base(context) { }

        public AssemblyQuality CreateAssemblyQuality(AssemblyQuality assemblyQuality)
        {
            Create(assemblyQuality);
            return assemblyQuality;
        }

        public AssemblyQuality DeleteAssemblyQuality(AssemblyQuality assemblyQuality)
        {
            Delete(assemblyQuality);
            return assemblyQuality;
        }

        public async Task<IEnumerable<AssemblyQuality>> GetAllAssemblyQualityAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.QualityOfficer)
                .ToListAsync();
        }

        public async Task<IEnumerable<AssemblyQuality>> GetAllAssemblyQualityByFailureAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.AssemblyFailureStateID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.QualityOfficer)
                .ToListAsync();
        }

        public async Task<AssemblyQuality> GetAssemblyQualityByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.QualityOfficer)
                .SingleOrDefaultAsync();
        }

        public AssemblyQuality UpdateAssemblyQuality(AssemblyQuality assemblyQuality)
        {
            Update(assemblyQuality);
            return assemblyQuality;
        }
    }
}
