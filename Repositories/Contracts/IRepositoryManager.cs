namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IAssemblyFailureStateRepository AssemblyFailureStateRepository { get; }
        IAssemblyManuelRepository AssemblyManuelRepository { get; }
        IAssemblyNoteRepository AssemblyNoteRepository { get; }
        IAssemblySuccessStateRepository AssemblySuccessStateRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        ILogRepository LogRepository { get; }
        IProductRepository ProductRepository { get; }
        IServicesRepository ServicesRepository { get; }
        IUserRepository UserRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }
        Task SaveAsync();
    }
}
