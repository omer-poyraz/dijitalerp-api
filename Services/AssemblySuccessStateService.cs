using AutoMapper;
using Entities.DTOs.AssemblySuccessStateDto;
using Entities.Models;
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
            try
            {
                var assemblySuccessStateGroup = _mapper.Map<AssemblySuccessState>(assemblySuccessStateGroupDtoForInsertion);
                ConvertDatesToUtc(assemblySuccessStateGroupDtoForInsertion);
                _manager.AssemblySuccessStateRepository.CreateAssemblySuccessState(assemblySuccessStateGroup);
                await _manager.SaveAsync();
                return _mapper.Map<AssemblySuccessStateDto>(assemblySuccessStateGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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

        public async Task<IEnumerable<AssemblySuccessStateDto>> GetAllAssemblySuccessStateByManualAsync(int id, bool? trackChanges)
        {
            var assemblySuccessStateGroup = await _manager.AssemblySuccessStateRepository.GetAllAssemblySuccessStateByManualAsync(id, trackChanges);
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
            ConvertDatesToUtc(assemblySuccessStateGroupDtoForUpdate);
            _mapper.Map(assemblySuccessStateGroupDtoForUpdate, assemblySuccessStateGroup);
            _manager.AssemblySuccessStateRepository.UpdateAssemblySuccessState(assemblySuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblySuccessStateDto>(assemblySuccessStateGroup);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : AssemblySuccessStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }
    }
}
