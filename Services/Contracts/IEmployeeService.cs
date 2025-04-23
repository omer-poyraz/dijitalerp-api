using Entities.DTOs.EmployeeDto;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync(bool? trackChanges);
        Task<EmployeeDto> GetEmployeeByIdAsync(int id, bool? trackChanges);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDtoForInsertion employeeDtoForInsertion);
        Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDtoForUpdate employeeDtoForUpdate);
        Task<EmployeeDto> DeleteEmployeeAsync(int id, bool? trackChanges);
    }
}
