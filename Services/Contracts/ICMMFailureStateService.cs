using Entities.DTOs.CMMFailureStateDto;

namespace Services.Contracts
{
    public interface ICMMFailureStateService
    {
        Task<IEnumerable<CMMFailureStateDto>> GetAllCMMFailureStateAsync(bool? trackChanges);
        Task<IEnumerable<CMMFailureStateDto>> GetAllCMMFailureStateByManualAsync(int id, bool? trackChanges);
        Task<CMMFailureStateDto> GetCMMFailureStateByIdAsync(int id, bool? trackChanges);
        Task<CMMFailureStateDto> CreateCMMFailureStateAsync(CMMFailureStateDtoForInsertion cmmFailureStateDtoForInsertion);
        Task<CMMFailureStateDto> UpdateCMMFailureStateAsync(CMMFailureStateDtoForUpdate cmmFailureStateDtoForUpdate);
        Task<CMMFailureStateDto> DeleteCMMFailureStateAsync(int id, bool? trackChanges);
    }
}
