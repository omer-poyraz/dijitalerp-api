using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICMMSuccessStateRepository : IRepositoryBase<CMMSuccessState>
    {
        Task<IEnumerable<CMMSuccessState>> GetAllCMMSuccessStateAsync(bool? trackChanges);
        Task<IEnumerable<CMMSuccessState>> GetAllCMMSuccessStateByManualAsync(int id, bool? trackChanges);
        Task<CMMSuccessState> GetCMMSuccessStateByIdAsync(int id, bool? trackChanges);
        CMMSuccessState CreateCMMSuccessState(CMMSuccessState cmmSuccessState);
        CMMSuccessState UpdateCMMSuccessState(CMMSuccessState cmmSuccessState);
        CMMSuccessState DeleteCMMSuccessState(CMMSuccessState cmmSuccessState);
    }
}
