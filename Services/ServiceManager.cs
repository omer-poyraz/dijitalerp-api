using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAssemblyFailureStateService _assemblyFailureStateService;
        private readonly IAssemblyManuelService _assemblyManuelService;
        private readonly IAssemblyNoteService _assemblyNoteService;
        private readonly IAssemblySuccessStateService _assemblySuccessStateService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly ILogService _logService;
        private readonly IProductService _productService;
        private readonly IServicesService _servicesService;
        private readonly ITechnicalDrawingService _technicalDrawingService;
        private readonly ITechnicalDrawingFailureStateService _technicalDrawingFailureStateService;
        private readonly ITechnicalDrawingSuccessStateService _technicalDrawingSuccessStateService;
        private readonly ITechnicalDrawingNoteService _technicalDrawingNoteService;
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;

        public ServiceManager(
            IAuthenticationService authenticationService,
            IServicesService servicesService,
            IUserService userService,
            IUserPermissionService userPermissionService,
            ILogService logService,
            IDepartmentService departmentService,
            IAssemblyFailureStateService assemblyFailureStateService,
            IAssemblyManuelService assemblyManuelService,
            IAssemblyNoteService assemblyNoteService,
            IAssemblySuccessStateService assemblySuccessStateService,
            IProductService productService,
            IEmployeeService employeeService,
            ITechnicalDrawingService technicalDrawingService,
            ITechnicalDrawingFailureStateService technicalDrawingFailureStateService,
            ITechnicalDrawingSuccessStateService technicalDrawingSuccessStateService,
            ITechnicalDrawingNoteService technicalDrawingNoteService)
        {
            _authenticationService = authenticationService;
            _assemblyFailureStateService = assemblyFailureStateService;
            _assemblyManuelService = assemblyManuelService;
            _assemblyNoteService = assemblyNoteService;
            _assemblySuccessStateService = assemblySuccessStateService;
            _departmentService = departmentService;
            _employeeService = employeeService;
            _logService = logService;
            _productService = productService;
            _servicesService = servicesService;
            _technicalDrawingService = technicalDrawingService;
            _technicalDrawingFailureStateService = technicalDrawingFailureStateService;
            _technicalDrawingSuccessStateService = technicalDrawingSuccessStateService;
            _technicalDrawingNoteService = technicalDrawingNoteService;
            _userService = userService;
            _userPermissionService = userPermissionService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IAssemblyFailureStateService AssemblyFailureStateService => _assemblyFailureStateService;
        public IAssemblyManuelService AssemblyManuelService => _assemblyManuelService;
        public IAssemblyNoteService AssemblyNoteService => _assemblyNoteService;
        public IAssemblySuccessStateService AssemblySuccessStateService => _assemblySuccessStateService;
        public IDepartmentService DepartmentService => _departmentService;
        public IEmployeeService EmployeeService => _employeeService;
        public ILogService LogService => _logService;
        public IProductService ProductService => _productService;
        public IServicesService ServicesService => _servicesService;
        public ITechnicalDrawingService TechnicalDrawingService => _technicalDrawingService;
        public ITechnicalDrawingFailureStateService TechnicalDrawingFailureStateService => _technicalDrawingFailureStateService;
        public ITechnicalDrawingSuccessStateService TechnicalDrawingSuccessStateService => _technicalDrawingSuccessStateService;
        public ITechnicalDrawingNoteService TechnicalDrawingNoteService => _technicalDrawingNoteService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
    }
}
