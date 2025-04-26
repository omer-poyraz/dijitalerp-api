using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IAssemblyFailureStateRepository _assemblyFailureStateRepository;
        private readonly IAssemblyManuelRepository _assemblyManuelRepository;
        private readonly IAssemblyNoteRepository _assemblyNoteRepository;
        private readonly IAssemblySuccessStateRepository _assemblySuccessStateRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogRepository _logRepository;
        private readonly IProductRepository _productRepository;
        private readonly RepositoryContext _context;
        private readonly IServicesRepository _servicesRepository;
        private readonly ITechnicalDrawingRepository _technicalDrawingRepository;
        private readonly ITechnicalDrawingFailureStateRepository _technicalDrawingFailureStateRepository;
        private readonly ITechnicalDrawingSuccessStateRepository _technicalDrawingSuccessStateRepository;
        private readonly ITechnicalDrawingNoteRepository _technicalDrawingNoteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public RepositoryManager(
            RepositoryContext context,
            IServicesRepository servicesRepository,
            IUserRepository userRepository,
            IUserPermissionRepository userPermissionRepository,
            ILogRepository logRepository,
            IDepartmentRepository departmentRepository,
            IAssemblyFailureStateRepository assemblyFailureStateRepository,
            IAssemblyManuelRepository assemblyManuelRepository,
            IAssemblyNoteRepository assemblyNoteRepository,
            IAssemblySuccessStateRepository assemblySuccessStateRepository,
            IProductRepository productRepository,
            IEmployeeRepository employeeRepository,
            ITechnicalDrawingRepository technicalDrawingRepository,
            ITechnicalDrawingFailureStateRepository technicalDrawingFailureStateRepository,
            ITechnicalDrawingSuccessStateRepository technicalDrawingSuccessStateRepository,
            ITechnicalDrawingNoteRepository technicalDrawingNoteRepository)
        {
            _assemblyFailureStateRepository = assemblyFailureStateRepository;
            _assemblyManuelRepository = assemblyManuelRepository;
            _assemblyNoteRepository = assemblyNoteRepository;
            _assemblySuccessStateRepository = assemblySuccessStateRepository;
            _context = context;
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _logRepository = logRepository;
            _productRepository = productRepository;
            _servicesRepository = servicesRepository;
            _technicalDrawingRepository = technicalDrawingRepository;
            _technicalDrawingFailureStateRepository = technicalDrawingFailureStateRepository;
            _technicalDrawingSuccessStateRepository = technicalDrawingSuccessStateRepository;
            _technicalDrawingNoteRepository = technicalDrawingNoteRepository;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public IAssemblyFailureStateRepository AssemblyFailureStateRepository => _assemblyFailureStateRepository;
        public IAssemblyManuelRepository AssemblyManuelRepository => _assemblyManuelRepository;
        public IAssemblyNoteRepository AssemblyNoteRepository => _assemblyNoteRepository;
        public IAssemblySuccessStateRepository AssemblySuccessStateRepository => _assemblySuccessStateRepository;
        public IDepartmentRepository DepartmentRepository => _departmentRepository;
        public IEmployeeRepository EmployeeRepository => _employeeRepository;
        public ILogRepository LogRepository => _logRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IServicesRepository ServicesRepository => _servicesRepository;
        public ITechnicalDrawingRepository TechnicalDrawingRepository => _technicalDrawingRepository;
        public ITechnicalDrawingFailureStateRepository TechnicalDrawingFailureStateRepository => _technicalDrawingFailureStateRepository;
        public ITechnicalDrawingSuccessStateRepository TechnicalDrawingSuccessStateRepository => _technicalDrawingSuccessStateRepository;
        public ITechnicalDrawingNoteRepository TechnicalDrawingNoteRepository => _technicalDrawingNoteRepository;
        public IUserRepository UserRepository => _userRepository;
        public IUserPermissionRepository UserPermissionRepository => _userPermissionRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
