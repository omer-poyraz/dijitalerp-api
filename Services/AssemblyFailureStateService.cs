using AutoMapper;
using Entities.DTOs.AssemblyFailureStateDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AssemblyFailureStateService : IAssemblyFailureStateService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AssemblyFailureStateService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<AssemblyFailureStateDto> CreateAssemblyFailureStateAsync(
            AssemblyFailureStateDtoForInsertion assemblyFailureStateGroupDtoForInsertion
        )
        {
            var assemblyFailureStateGroup = _mapper.Map<Entities.Models.AssemblyFailureState>(assemblyFailureStateGroupDtoForInsertion);
            ConvertDatesToUtc(assemblyFailureStateGroupDtoForInsertion);
            _manager.AssemblyFailureStateRepository.CreateAssemblyFailureState(assemblyFailureStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureStateGroup);
        }

        public async Task<AssemblyFailureStateDto> DeleteAssemblyFailureStateAsync(int id, bool? trackChanges)
        {
            var assemblyFailureStateGroup = await _manager.AssemblyFailureStateRepository.GetAssemblyFailureStateByIdAsync(id, trackChanges);
            _manager.AssemblyFailureStateRepository.DeleteAssemblyFailureState(assemblyFailureStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureStateGroup);
        }

        public async Task<IEnumerable<AssemblyFailureStateDto>> GetAllAssemblyFailureStateAsync(bool? trackChanges)
        {
            var assemblyFailureStateGroup = await _manager.AssemblyFailureStateRepository.GetAllAssemblyFailureStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<AssemblyFailureStateDto>>(assemblyFailureStateGroup);
        }

        public async Task<IEnumerable<AssemblyFailureStateDto>> GetAllAssemblyFailureStateByManualAsync(int id, bool? trackChanges)
        {
            var assemblyFailureStateGroup = await _manager.AssemblyFailureStateRepository.GetAllAssemblyFailureStateByManualAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<AssemblyFailureStateDto>>(assemblyFailureStateGroup);
        }

        public async Task<AssemblyFailureStateDto> GetAssemblyFailureStateByIdAsync(int id, bool? trackChanges)
        {
            var assemblyFailureStateGroup = await _manager.AssemblyFailureStateRepository.GetAssemblyFailureStateByIdAsync(id, trackChanges);
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureStateGroup);
        }

        public async Task<AssemblyFailureStateDto> UpdateAssemblyFailureStateAsync(AssemblyFailureStateDtoForUpdate assemblyFailureStateGroupDtoForUpdate)
        {
            var assemblyFailureStateGroup = await _manager.AssemblyFailureStateRepository.GetAssemblyFailureStateByIdAsync(assemblyFailureStateGroupDtoForUpdate.ID, assemblyFailureStateGroupDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(assemblyFailureStateGroupDtoForUpdate);
            _mapper.Map(assemblyFailureStateGroupDtoForUpdate, assemblyFailureStateGroup);
            _manager.AssemblyFailureStateRepository.UpdateAssemblyFailureState(assemblyFailureStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureStateGroup);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : AssemblyFailureStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }
    }
}
