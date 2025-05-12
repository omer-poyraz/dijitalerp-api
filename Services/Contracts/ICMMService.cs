using Entities.DTOs.CMMDto;

namespace Services.Contracts
{
    public interface ICMMService
    {
        Task<IEnumerable<CMMDto>> GetAllCMMAsync(bool? trackChanges);
        Task<CMMDto> GetCMMByIdAsync(int id, bool? trackChanges);
        Task<CMMDto> CreateCMMAsync(CMMDtoForInsertion cmmDtoForInsertion);
        Task<CMMDto> UpdateCMMAsync(CMMDtoForUpdate cmmDtoForUpdate);
        Task<CMMDto> AddFileCMMAsync(CMMDtoForAddFile cmmDtoForAddFile);
        Task<CMMDto> AddResultFileCMMAsync(CMMDtoForAddResultFile cmmDtoForAddResultFile);
        Task<CMMDto> DeleteCMMAsync(int id, bool? trackChanges);
    }
}
