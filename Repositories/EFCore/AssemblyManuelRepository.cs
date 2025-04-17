using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class AssemblyManuelRepository : RepositoryBase<AssemblyManuel>, IAssemblyManuelRepository
    {
        public AssemblyManuelRepository(RepositoryContext context) : base(context) { }

        public AssemblyManuel CreateAssemblyManuel(AssemblyManuel assemblyManuel)
        {
            Create(assemblyManuel);
            return assemblyManuel;
        }

        public AssemblyManuel DeleteAssemblyManuel(AssemblyManuel assemblyManuel)
        {
            Delete(assemblyManuel);
            return assemblyManuel;
        }

        public async Task<IEnumerable<AssemblyManuel>> GetAllAssemblyManuelAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();
        }

        public async Task<AssemblyManuel> GetAssemblyManuelByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public AssemblyManuel UpdateAssemblyManuel(AssemblyManuel assemblyManuel)
        {
            Update(assemblyManuel);
            return assemblyManuel;
        }
    }
}
