using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RepositoryContext context) : base(context) { }

        public Department CreateDepartment(Department department)
        {
            Create(department);
            return department;
        }

        public Department DeleteDepartment(Department department)
        {
            Delete(department);
            return department;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.ID).ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public Department UpdateDepartment(Department department)
        {
            Update(department);
            return department;
        }
    }
}
