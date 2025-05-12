namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IAssemblyFailureStateService AssemblyFailureStateService { get; }
        IAssemblyManuelService AssemblyManuelService { get; }
        IAssemblyNoteService AssemblyNoteService { get; }
        IAssemblyVisualNoteService AssemblyVisualNoteService { get; }
        IAssemblySuccessStateService AssemblySuccessStateService { get; }
        IAssemblyQualityService AssemblyQualityService { get; }
        ICMMService CMMService { get; }
        ICMMModuleService CMMModuleService { get; }
        ICMMFailureStateService CMMFailureStateService { get; }
        ICMMSuccessStateService CMMSuccessStateService { get; }
        ICMMNoteService CMMNoteService { get; }
        IDepartmentService DepartmentService { get; }
        IEmployeeService EmployeeService { get; }
        ILogService LogService { get; }
        IProductService ProductService { get; }
        IServicesService ServicesService { get; }
        ITechnicalDrawingService TechnicalDrawingService { get; }
        ITechnicalDrawingFailureStateService TechnicalDrawingFailureStateService { get; }
        ITechnicalDrawingSuccessStateService TechnicalDrawingSuccessStateService { get; }
        ITechnicalDrawingNoteService TechnicalDrawingNoteService { get; }
        ITechnicalDrawingVisualNoteService TechnicalDrawingVisualNoteService { get; }
        ITechnicalDrawingQualityService TechnicalDrawingQualityService { get; }
        IUserService UserService { get; }
        IUserPermissionService UserPermissionService { get; }
    }
}
