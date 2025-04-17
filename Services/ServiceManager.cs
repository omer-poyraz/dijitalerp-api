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
        private readonly ILogService _logService;
        private readonly IProductService _productService;
        private readonly IServicesService _servicesService;
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
            IProductService productService)
        {
            _authenticationService = authenticationService;
            _assemblyFailureStateService = assemblyFailureStateService;
            _assemblyManuelService = assemblyManuelService;
            _assemblyNoteService = assemblyNoteService;
            _assemblySuccessStateService = assemblySuccessStateService;
            _departmentService = departmentService;
            _logService = logService;
            _servicesService = servicesService;
            _userService = userService;
            _userPermissionService = userPermissionService;
            _productService = productService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IAssemblyFailureStateService AssemblyFailureStateService => _assemblyFailureStateService;
        public IAssemblyManuelService AssemblyManuelService => _assemblyManuelService;
        public IAssemblyNoteService AssemblyNoteService => _assemblyNoteService;
        public IAssemblySuccessStateService AssemblySuccessStateService => _assemblySuccessStateService;
        public IDepartmentService DepartmentService => _departmentService;
        public ILogService LogService => _logService;
        public IProductService ProductService => _productService;
        public IServicesService ServicesService => _servicesService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
    }
}
