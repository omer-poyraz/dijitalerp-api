using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context) { }

        public Employee CreateEmployee(Employee employee)
        {
            Create(employee);
            return employee;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            Delete(employee);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges).Include(s => s.User).SingleOrDefaultAsync();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Update(employee);
            return employee;
        }
    }
}
