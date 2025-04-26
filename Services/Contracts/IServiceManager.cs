namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IAssemblyFailureStateService AssemblyFailureStateService { get; }
        IAssemblyManuelService AssemblyManuelService { get; }
        IAssemblyNoteService AssemblyNoteService { get; }
        IAssemblySuccessStateService AssemblySuccessStateService { get; }
        IDepartmentService DepartmentService { get; }
        IEmployeeService EmployeeService { get; }
        ILogService LogService { get; }
        IProductService ProductService { get; }
        IServicesService ServicesService { get; }
        ITechnicalDrawingService TechnicalDrawingService { get; }
        ITechnicalDrawingFailureStateService TechnicalDrawingFailureStateService { get; }
        ITechnicalDrawingSuccessStateService TechnicalDrawingSuccessStateService { get; }
        ITechnicalDrawingNoteService TechnicalDrawingNoteService { get; }
        IUserService UserService { get; }
        IUserPermissionService UserPermissionService { get; }
    }
}
