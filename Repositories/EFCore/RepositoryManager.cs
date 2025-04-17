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
        private readonly ILogRepository _logRepository;
        private readonly IProductRepository _productRepository;
        private readonly RepositoryContext _context;
        private readonly IServicesRepository _servicesRepository;
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
            IProductRepository productRepository)
        {
            _assemblyFailureStateRepository = assemblyFailureStateRepository;
            _assemblyManuelRepository = assemblyManuelRepository;
            _assemblyNoteRepository = assemblyNoteRepository;
            _assemblySuccessStateRepository = assemblySuccessStateRepository;
            _context = context;
            _departmentRepository = departmentRepository;
            _logRepository = logRepository;
            _servicesRepository = servicesRepository;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
            _productRepository = productRepository;
        }

        public IAssemblyFailureStateRepository AssemblyFailureStateRepository => _assemblyFailureStateRepository;
        public IAssemblyManuelRepository AssemblyManuelRepository => _assemblyManuelRepository;
        public IAssemblyNoteRepository AssemblyNoteRepository => _assemblyNoteRepository;
        public IAssemblySuccessStateRepository AssemblySuccessStateRepository => _assemblySuccessStateRepository;
        public IDepartmentRepository DepartmentRepository => _departmentRepository;
        public ILogRepository LogRepository => _logRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IServicesRepository ServicesRepository => _servicesRepository;
        public IUserRepository UserRepository => _userRepository;
        public IUserPermissionRepository UserPermissionRepository => _userPermissionRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
