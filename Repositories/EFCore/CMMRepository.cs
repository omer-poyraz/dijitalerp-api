using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CMMRepository : RepositoryBase<CMM>, ICMMRepository
    {
        public CMMRepository(RepositoryContext context) : base(context) { }

        public CMM CreateCMM(CMM cmm)
        {
            Create(cmm);
            return cmm;
        }

        public CMM DeleteCMM(CMM cmm)
        {
            Delete(cmm);
            return cmm;
        }

        public async Task<IEnumerable<CMM>> GetAllCMMAsync(bool? trackChanges)
        {
            try
            {
                return await FindAll(trackChanges)
                    .OrderBy(s => s.ID)
                    .Include(s => s.BasariliDurumlar)
                    .Include(s => s.BasarisizDurumlar)
                    .Include(s => s.Responible)
                    .Include(s => s.PersonInCharge)
                    .Include(s => s.User)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CMM> GetCMMByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.BasariliDurumlar)
                .Include(s => s.BasarisizDurumlar)
                .Include(s => s.Responible)
                .Include(s => s.PersonInCharge)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public CMM AddFileCMM(CMM cmm)
        {
            Update(cmm);
            return cmm;
        }

        public CMM AddResultFileCMM(CMM cmm)
        {
            Update(cmm);
            return cmm;
        }

        public CMM UpdateCMM(CMM cmm)
        {
            Update(cmm);
            return cmm;
        }
    }
}
