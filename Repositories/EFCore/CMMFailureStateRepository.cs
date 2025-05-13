using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CMMFailureStateRepository : RepositoryBase<CMMFailureState>, ICMMFailureStateRepository
    {
        public CMMFailureStateRepository(RepositoryContext context) : base(context) { }

        public CMMFailureState CreateCMMFailureState(CMMFailureState cmmFailureState)
        {
            Create(cmmFailureState);
            return cmmFailureState;
        }

        public CMMFailureState DeleteCMMFailureState(CMMFailureState cmmFailureState)
        {
            Delete(cmmFailureState);
            return cmmFailureState;
        }

        public async Task<IEnumerable<CMMFailureState>> GetAllCMMFailureStateAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<CMMFailureState>> GetAllCMMFailureStateByManualAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.CMMID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<CMMFailureState> GetCMMFailureStateByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public CMMFailureState UpdateCMMFailureByQualityState(CMMFailureState cmmFailureState)
        {
            Update(cmmFailureState);
            return cmmFailureState;
        }

        public CMMFailureState UpdateCMMFailureState(CMMFailureState cmmFailureState)
        {
            Update(cmmFailureState);
            return cmmFailureState;
        }
    }
}
