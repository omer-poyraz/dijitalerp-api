using AutoMapper;
using Entities.DTOs.EmployeeDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDtoForInsertion employeeDtoForInsertion)
        {
            ConvertDatesToUtc(employeeDtoForInsertion);
            var employee = _mapper.Map<Entities.Models.Employee>(employeeDtoForInsertion);
            _manager.EmployeeRepository.CreateEmployee(employee);
            await _manager.SaveAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> DeleteEmployeeAsync(int id, bool? trackChanges)
        {
            var employee = await _manager.EmployeeRepository.GetEmployeeByIdAsync(id, trackChanges);
            _manager.EmployeeRepository.DeleteEmployee(employee);
            await _manager.SaveAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync(bool? trackChanges)
        {
            var employee = await _manager.EmployeeRepository.GetAllEmployeeAsync(trackChanges);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employee);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id, bool? trackChanges)
        {
            var employee = await _manager.EmployeeRepository.GetEmployeeByIdAsync(id, trackChanges);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDtoForUpdate employeeDtoForUpdate)
        {
            var employee = await _manager.EmployeeRepository.GetEmployeeByIdAsync(employeeDtoForUpdate.ID, employeeDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(employeeDtoForUpdate);
            if (employeeDtoForUpdate.file == null)
            {
                employeeDtoForUpdate.File = employee.File;
            }
            _mapper.Map(employeeDtoForUpdate, employee);
            _manager.EmployeeRepository.UpdateEmployee(employee);
            await _manager.SaveAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : EmployeeDtoForManipulation
        {
            if (dto.Birthday.HasValue)
                dto.Birthday = DateTime.SpecifyKind(dto.Birthday.Value, DateTimeKind.Utc);

            if (dto.StartDate.HasValue)
                dto.StartDate = DateTime.SpecifyKind(dto.StartDate.Value, DateTimeKind.Utc);
        }
    }
}
