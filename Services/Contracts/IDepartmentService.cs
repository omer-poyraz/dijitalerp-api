using Entities.DTOs.DepartmentDto;

namespace Services.Contracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentAsync(bool? trackChanges);
        Task<DepartmentDto> GetDepartmentByIdAsync(int id, bool? trackChanges);
        Task<DepartmentDto> CreateDepartmentAsync(DepartmentDtoForInsertion departmentDtoForInsertion);
        Task<DepartmentDto> UpdateDepartmentAsync(DepartmentDtoForUpdate departmentDtoForUpdate);
        Task<DepartmentDto> DeleteDepartmentAsync(int id, bool? trackChanges);
    }
}
