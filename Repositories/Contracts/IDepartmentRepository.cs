using Entities.Models;

namespace Repositories.Contracts
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync(bool? trackChanges);
        Task<Department> GetDepartmentByIdAsync(int id, bool? trackChanges);
        Department CreateDepartment(Department department);
        Department UpdateDepartment(Department department);
        Department DeleteDepartment(Department department);
    }
}
