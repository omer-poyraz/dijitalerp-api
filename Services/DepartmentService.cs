using AutoMapper;
using Entities.DTOs.DepartmentDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public DepartmentService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(
            DepartmentDtoForInsertion departmentGroupDtoForInsertion
        )
        {
            var departmentGroup = _mapper.Map<Entities.Models.Department>(departmentGroupDtoForInsertion);
            _manager.DepartmentRepository.CreateDepartment(departmentGroup);
            await _manager.SaveAsync();
            return _mapper.Map<DepartmentDto>(departmentGroup);
        }

        public async Task<DepartmentDto> DeleteDepartmentAsync(int id, bool? trackChanges)
        {
            var departmentGroup = await _manager.DepartmentRepository.GetDepartmentByIdAsync(id, trackChanges);
            _manager.DepartmentRepository.DeleteDepartment(departmentGroup);
            await _manager.SaveAsync();
            return _mapper.Map<DepartmentDto>(departmentGroup);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentAsync(bool? trackChanges)
        {
            var departmentGroup = await _manager.DepartmentRepository.GetAllDepartmentAsync(trackChanges);
            return _mapper.Map<IEnumerable<DepartmentDto>>(departmentGroup);
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id, bool? trackChanges)
        {
            var departmentGroup = await _manager.DepartmentRepository.GetDepartmentByIdAsync(id, trackChanges);
            return _mapper.Map<DepartmentDto>(departmentGroup);
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(DepartmentDtoForUpdate departmentGroupDtoForUpdate)
        {
            var departmentGroup = await _manager.DepartmentRepository.GetDepartmentByIdAsync(departmentGroupDtoForUpdate.ID, departmentGroupDtoForUpdate.TrackChanges);
            _mapper.Map(departmentGroupDtoForUpdate, departmentGroup);
            _manager.DepartmentRepository.UpdateDepartment(departmentGroup);
            await _manager.SaveAsync();
            return _mapper.Map<DepartmentDto>(departmentGroup);
        }
    }
}
