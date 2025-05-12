using Entities.DTOs.CMMSuccessStateDto;

namespace Services.Contracts
{
    public interface ICMMSuccessStateService
    {
        Task<IEnumerable<CMMSuccessStateDto>> GetAllCMMSuccessStateAsync(bool? trackChanges);
        Task<IEnumerable<CMMSuccessStateDto>> GetAllCMMSuccessStateByManualAsync(int id, bool? trackChanges);
        Task<CMMSuccessStateDto> GetCMMSuccessStateByIdAsync(int id, bool? trackChanges);
        Task<CMMSuccessStateDto> CreateCMMSuccessStateAsync(CMMSuccessStateDtoForInsertion cmmSuccessStateDtoForInsertion);
        Task<CMMSuccessStateDto> UpdateCMMSuccessStateAsync(CMMSuccessStateDtoForUpdate cmmSuccessStateDtoForUpdate);
        Task<CMMSuccessStateDto> DeleteCMMSuccessStateAsync(int id, bool? trackChanges);
    }
}
