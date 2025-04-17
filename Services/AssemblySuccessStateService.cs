using AutoMapper;
using Entities.DTOs.AssemblySuccessStateDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AssemblySuccessStateService : IAssemblySuccessStateService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AssemblySuccessStateService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<AssemblySuccessStateDto> CreateAssemblySuccessStateAsync(
            AssemblySuccessStateDtoForInsertion assemblySuccessStateGroupDtoForInsertion
        )
        {
            var assemblySuccessStateGroup = _mapper.Map<Entities.Models.AssemblySuccessState>(assemblySuccessStateGroupDtoForInsertion);
            _manager.AssemblySuccessStateRepository.CreateAssemblySuccessState(assemblySuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblySuccessStateDto>(assemblySuccessStateGroup);
        }

        public async Task<AssemblySuccessStateDto> DeleteAssemblySuccessStateAsync(int id, bool? trackChanges)
        {
            var assemblySuccessStateGroup = await _manager.AssemblySuccessStateRepository.GetAssemblySuccessStateByIdAsync(id, trackChanges);
            _manager.AssemblySuccessStateRepository.DeleteAssemblySuccessState(assemblySuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblySuccessStateDto>(assemblySuccessStateGroup);
        }

        public async Task<IEnumerable<AssemblySuccessStateDto>> GetAllAssemblySuccessStateAsync(bool? trackChanges)
        {
            var assemblySuccessStateGroup = await _manager.AssemblySuccessStateRepository.GetAllAssemblySuccessStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<AssemblySuccessStateDto>>(assemblySuccessStateGroup);
        }

        public async Task<AssemblySuccessStateDto> GetAssemblySuccessStateByIdAsync(int id, bool? trackChanges)
        {
            var assemblySuccessStateGroup = await _manager.AssemblySuccessStateRepository.GetAssemblySuccessStateByIdAsync(id, trackChanges);
            return _mapper.Map<AssemblySuccessStateDto>(assemblySuccessStateGroup);
        }

        public async Task<AssemblySuccessStateDto> UpdateAssemblySuccessStateAsync(AssemblySuccessStateDtoForUpdate assemblySuccessStateGroupDtoForUpdate)
        {
            var assemblySuccessStateGroup = await _manager.AssemblySuccessStateRepository.GetAssemblySuccessStateByIdAsync(assemblySuccessStateGroupDtoForUpdate.ID, assemblySuccessStateGroupDtoForUpdate.TrackChanges);
            _mapper.Map(assemblySuccessStateGroupDtoForUpdate, assemblySuccessStateGroup);
            _manager.AssemblySuccessStateRepository.UpdateAssemblySuccessState(assemblySuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblySuccessStateDto>(assemblySuccessStateGroup);
        }
    }
}
