using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICMMModuleRepository : IRepositoryBase<CMMModule>
    {
        Task<IEnumerable<CMMModule>> GetAllCMMModuleAsync(bool? trackChanges);
        Task<CMMModule> GetCMMModuleByIdAsync(int id, bool? trackChanges);
        CMMModule CreateCMMModule(CMMModule cmmModule);
        CMMModule UpdateCMMModule(CMMModule cmmModule);
        CMMModule AddFileCMMModule(CMMModule cmmModule);
        CMMModule DeleteCMMModule(CMMModule cmmModule);
    }
}
