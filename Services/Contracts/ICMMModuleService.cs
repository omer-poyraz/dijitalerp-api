using Entities.DTOs.CMMModuleDto;

namespace Services.Contracts
{
    public interface ICMMModuleService
    {
        Task<IEnumerable<CMMModuleDto>> GetAllCMMModuleAsync(bool? trackChanges);
        Task<CMMModuleDto> GetCMMModuleByIdAsync(int id, bool? trackChanges);
        Task<CMMModuleDto> CreateCMMModuleAsync(CMMModuleDtoForInsertion cmmModuleDtoForInsertion);
        Task<CMMModuleDto> UpdateCMMModuleAsync(CMMModuleDtoForUpdate cmmModuleDtoForUpdate);
        Task<CMMModuleDto> AddFileCMMModuleAsync(CMMModuleDtoForAddFile cmmModuleDtoForAddFile);
        Task<CMMModuleDto> DeleteCMMModuleAsync(int id, bool? trackChanges);
    }
}
