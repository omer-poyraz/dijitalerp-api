using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICMMRepository : IRepositoryBase<CMM>
    {
        Task<IEnumerable<CMM>> GetAllCMMAsync(bool? trackChanges);
        Task<CMM> GetCMMByIdAsync(int id, bool? trackChanges);
        CMM CreateCMM(CMM cmm);
        CMM UpdateCMM(CMM cmm);
        CMM AddFileCMM(CMM cmm);
        CMM AddResultFileCMM(CMM cmm);
        CMM DeleteCMM(CMM cmm);
    }
}
