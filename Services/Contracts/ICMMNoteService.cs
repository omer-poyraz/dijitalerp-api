using Entities.DTOs.CMMNoteDto;

namespace Services.Contracts
{
    public interface ICMMNoteService
    {
        Task<IEnumerable<CMMNoteDto>> GetAllCMMNoteAsync(bool? trackChanges);
        Task<IEnumerable<CMMNoteDto>> GetAllCMMNoteByManualAsync(int id, bool? trackChanges);
        Task<CMMNoteDto> GetCMMNoteByIdAsync(int id, bool? trackChanges);
        Task<CMMNoteDto> CreateCMMNoteAsync(CMMNoteDtoForInsertion cmmNoteDtoForInsertion);
        Task<CMMNoteDto> UpdateCMMNoteAsync(CMMNoteDtoForUpdate cmmNoteDtoForUpdate);
        Task<CMMNoteDto> DeleteCMMNoteAsync(int id, bool? trackChanges);
    }
}
