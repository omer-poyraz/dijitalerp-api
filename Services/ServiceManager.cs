using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAssemblyFailureStateService _assemblyFailureStateService;
        private readonly IAssemblyManuelService _assemblyManuelService;
        private readonly IAssemblyNoteService _assemblyNoteService;
        private readonly IAssemblyVisualNoteService _assemblyVisualNoteService;
        private readonly IAssemblySuccessStateService _assemblySuccessStateService;
        private readonly IAssemblyQualityService _assemblyQualityService;
        private readonly ICMMService _cmmService;
        private readonly ICMMModuleService _cmmModuleService;
        private readonly ICMMFailureStateService _cmmFailureStateService;
        private readonly ICMMSuccessStateService _cmmSuccessStateService;
        private readonly ICMMNoteService _cmmNoteService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly ILogService _logService;
        private readonly IProductService _productService;
        private readonly IServicesService _servicesService;
        private readonly ITechnicalDrawingService _technicalDrawingService;
        private readonly ITechnicalDrawingFailureStateService _technicalDrawingFailureStateService;
        private readonly ITechnicalDrawingSuccessStateService _technicalDrawingSuccessStateService;
        private readonly ITechnicalDrawingNoteService _technicalDrawingNoteService;
        private readonly ITechnicalDrawingVisualNoteService _technicalDrawingVisualNoteService;
        private readonly ITechnicalDrawingQualityService _technicalDrawingQualityService;
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;

        public ServiceManager(
            IAssemblyFailureStateService assemblyFailureStateService,
            IAssemblyManuelService assemblyManuelService,
            IAssemblyNoteService assemblyNoteService,
            IAssemblyVisualNoteService assemblyVisualNoteService,
            IAssemblySuccessStateService assemblySuccessStateService,
            IAssemblyQualityService assemblyQualityService,
            IAuthenticationService authenticationService,
            ICMMService cmmService,
            ICMMModuleService cmmModuleService,
            ICMMFailureStateService cmmFailureStateService,
            ICMMSuccessStateService cmmSuccessStateService,
            ICMMNoteService cmmNoteService,
            IDepartmentService departmentService,
            IEmployeeService employeeService,
            ILogService logService,
            IProductService productService,
            IServicesService servicesService,
            ITechnicalDrawingService technicalDrawingService,
            ITechnicalDrawingFailureStateService technicalDrawingFailureStateService,
            ITechnicalDrawingSuccessStateService technicalDrawingSuccessStateService,
            ITechnicalDrawingNoteService technicalDrawingNoteService,
            ITechnicalDrawingVisualNoteService technicalDrawingVisualNoteService,
            ITechnicalDrawingQualityService technicalDrawingQualityService,
            IUserService userService,
            IUserPermissionService userPermissionService
            )
        {
            _assemblyFailureStateService = assemblyFailureStateService;
            _assemblyManuelService = assemblyManuelService;
            _assemblyNoteService = assemblyNoteService;
            _assemblyVisualNoteService = assemblyVisualNoteService;
            _assemblySuccessStateService = assemblySuccessStateService;
            _assemblyQualityService = assemblyQualityService;
            _authenticationService = authenticationService;
            _cmmService = cmmService;
            _cmmModuleService = cmmModuleService;
            _cmmFailureStateService = cmmFailureStateService;
            _cmmSuccessStateService = cmmSuccessStateService;
            _cmmNoteService = cmmNoteService;
            _departmentService = departmentService;
            _employeeService = employeeService;
            _logService = logService;
            _productService = productService;
            _servicesService = servicesService;
            _technicalDrawingService = technicalDrawingService;
            _technicalDrawingFailureStateService = technicalDrawingFailureStateService;
            _technicalDrawingSuccessStateService = technicalDrawingSuccessStateService;
            _technicalDrawingNoteService = technicalDrawingNoteService;
            _technicalDrawingVisualNoteService = technicalDrawingVisualNoteService;
            _technicalDrawingQualityService = technicalDrawingQualityService;
            _userService = userService;
            _userPermissionService = userPermissionService;
        }

        public IAssemblyFailureStateService AssemblyFailureStateService => _assemblyFailureStateService;
        public IAssemblyManuelService AssemblyManuelService => _assemblyManuelService;
        public IAssemblyNoteService AssemblyNoteService => _assemblyNoteService;
        public IAssemblyVisualNoteService AssemblyVisualNoteService => _assemblyVisualNoteService;
        public IAssemblySuccessStateService AssemblySuccessStateService => _assemblySuccessStateService;
        public IAssemblyQualityService AssemblyQualityService => _assemblyQualityService;
        public IAuthenticationService AuthenticationService => _authenticationService;
        public ICMMService CMMService => _cmmService;
        public ICMMModuleService CMMModuleService => _cmmModuleService;
        public ICMMFailureStateService CMMFailureStateService => _cmmFailureStateService;
        public ICMMSuccessStateService CMMSuccessStateService => _cmmSuccessStateService;
        public ICMMNoteService CMMNoteService => _cmmNoteService;
        public IDepartmentService DepartmentService => _departmentService;
        public IEmployeeService EmployeeService => _employeeService;
        public ILogService LogService => _logService;
        public IProductService ProductService => _productService;
        public IServicesService ServicesService => _servicesService;
        public ITechnicalDrawingService TechnicalDrawingService => _technicalDrawingService;
        public ITechnicalDrawingFailureStateService TechnicalDrawingFailureStateService => _technicalDrawingFailureStateService;
        public ITechnicalDrawingSuccessStateService TechnicalDrawingSuccessStateService => _technicalDrawingSuccessStateService;
        public ITechnicalDrawingNoteService TechnicalDrawingNoteService => _technicalDrawingNoteService;
        public ITechnicalDrawingVisualNoteService TechnicalDrawingVisualNoteService => _technicalDrawingVisualNoteService;
        public ITechnicalDrawingQualityService TechnicalDrawingQualityService => _technicalDrawingQualityService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
    }
}
