using Entities.DTOs.AssemblyQualityDto;

namespace Services.Contracts
{
    public interface IAssemblyQualityService
    {
        Task<IEnumerable<AssemblyQualityDto>> GetAllAssemblyQualityAsync(bool? trackChanges);
        Task<IEnumerable<AssemblyQualityDto>> GetAllAssemblyQualityByFailureAsync(int id, bool? trackChanges);
        Task<AssemblyQualityDto> GetAssemblyQualityByIdAsync(int id, bool? trackChanges);
        Task<AssemblyQualityDto> CreateAssemblyQualityAsync(AssemblyQualityDtoForInsertion assemblyQualityDtoForInsertion);
        Task<AssemblyQualityDto> UpdateAssemblyQualityAsync(AssemblyQualityDtoForUpdate assemblyQualityDtoForUpdate);
        Task<AssemblyQualityDto> DeleteAssemblyQualityAsync(int id, bool? trackChanges);
    }
}
