using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CMMSuccessStateRepository : RepositoryBase<CMMSuccessState>, ICMMSuccessStateRepository
    {
        public CMMSuccessStateRepository(RepositoryContext context) : base(context) { }

        public CMMSuccessState CreateCMMSuccessState(CMMSuccessState cmmSuccessState)
        {
            Create(cmmSuccessState);
            return cmmSuccessState;
        }

        public CMMSuccessState DeleteCMMSuccessState(CMMSuccessState cmmSuccessState)
        {
            Delete(cmmSuccessState);
            return cmmSuccessState;
        }

        public async Task<IEnumerable<CMMSuccessState>> GetAllCMMSuccessStateAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<CMMSuccessState>> GetAllCMMSuccessStateByManualAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.CMMID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<CMMSuccessState> GetCMMSuccessStateByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.Technician)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public CMMSuccessState UpdateCMMSuccessState(CMMSuccessState cmmSuccessState)
        {
            Update(cmmSuccessState);
            return cmmSuccessState;
        }
    }
}
