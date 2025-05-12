namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IAssemblyFailureStateRepository AssemblyFailureStateRepository { get; }
        IAssemblyManuelRepository AssemblyManuelRepository { get; }
        IAssemblyNoteRepository AssemblyNoteRepository { get; }
        IAssemblyVisualNoteRepository AssemblyVisualNoteRepository { get; }
        IAssemblySuccessStateRepository AssemblySuccessStateRepository { get; }
        IAssemblyQualityRepository AssemblyQualityRepository { get; }
        ICMMFailureStateRepository CMMFailureStateRepository { get; }
        ICMMRepository CMMRepository { get; }
        ICMMModuleRepository CMMModuleRepository { get; }
        ICMMNoteRepository CMMNoteRepository { get; }
        ICMMSuccessStateRepository CMMSuccessStateRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        ILogRepository LogRepository { get; }
        IProductRepository ProductRepository { get; }
        IServicesRepository ServicesRepository { get; }
        ITechnicalDrawingFailureStateRepository TechnicalDrawingFailureStateRepository { get; }
        ITechnicalDrawingNoteRepository TechnicalDrawingNoteRepository { get; }
        ITechnicalDrawingVisualNoteRepository TechnicalDrawingVisualNoteRepository { get; }
        ITechnicalDrawingRepository TechnicalDrawingRepository { get; }
        ITechnicalDrawingSuccessStateRepository TechnicalDrawingSuccessStateRepository { get; }
        ITechnicalDrawingQualityRepository TechnicalDrawingQualityRepository { get; }
        IUserRepository UserRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }
        Task SaveAsync();
    }
}
