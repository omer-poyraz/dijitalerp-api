using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CMMModuleRepository : RepositoryBase<CMMModule>, ICMMModuleRepository
    {
        public CMMModuleRepository(RepositoryContext context) : base(context) { }

        public CMMModule CreateCMMModule(CMMModule cmmModule)
        {
            Create(cmmModule);
            return cmmModule;
        }

        public CMMModule DeleteCMMModule(CMMModule cmmModule)
        {
            Delete(cmmModule);
            return cmmModule;
        }

        public async Task<IEnumerable<CMMModule>> GetAllCMMModuleAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<CMMModule> GetCMMModuleByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public CMMModule AddFileCMMModule(CMMModule cmmModule)
        {
            Update(cmmModule);
            return cmmModule;
        }

        public CMMModule UpdateCMMModule(CMMModule cmmModule)
        {
            Update(cmmModule);
            return cmmModule;
        }
    }
}
