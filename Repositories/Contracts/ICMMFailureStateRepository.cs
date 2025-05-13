using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICMMFailureStateRepository : IRepositoryBase<CMMFailureState>
    {
        Task<IEnumerable<CMMFailureState>> GetAllCMMFailureStateAsync(bool? trackChanges);
        Task<IEnumerable<CMMFailureState>> GetAllCMMFailureStateByManualAsync(int id, bool? trackChanges);
        Task<CMMFailureState> GetCMMFailureStateByIdAsync(int id, bool? trackChanges);
        CMMFailureState CreateCMMFailureState(CMMFailureState cmmFailureState);
        CMMFailureState UpdateCMMFailureState(CMMFailureState cmmFailureState);
        CMMFailureState UpdateCMMFailureByQualityState(CMMFailureState cmmFailureState);
        CMMFailureState DeleteCMMFailureState(CMMFailureState cmmFailureState);
    }
}
