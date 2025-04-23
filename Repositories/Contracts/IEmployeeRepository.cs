using Entities.Models;

namespace Repositories.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync(bool? trackChanges);
        Task<Employee> GetEmployeeByIdAsync(int id, bool? trackChanges);
        Employee CreateEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(Employee employee);
    }
}
