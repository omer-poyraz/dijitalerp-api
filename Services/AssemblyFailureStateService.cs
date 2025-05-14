using AutoMapper;
using Entities.DTOs.AssemblyFailureStateDto;
using Entities.Models;
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
            AssemblyFailureStateDtoForInsertion assemblyFailureStateDtoForInsertion
        )
        {
            var assemblyFailureState = _mapper.Map<AssemblyFailureState>(assemblyFailureStateDtoForInsertion);
            ConvertDatesToUtc(assemblyFailureStateDtoForInsertion);
            _manager.AssemblyFailureStateRepository.CreateAssemblyFailureState(assemblyFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureState);
        }

        public async Task<AssemblyFailureStateDto> DeleteAssemblyFailureStateAsync(int id, bool? trackChanges)
        {
            var assemblyFailureState = await _manager.AssemblyFailureStateRepository.GetAssemblyFailureStateByIdAsync(id, trackChanges);
            _manager.AssemblyFailureStateRepository.DeleteAssemblyFailureState(assemblyFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureState);
        }

        public async Task<IEnumerable<AssemblyFailureStateDto>> GetAllAssemblyFailureStateAsync(bool? trackChanges)
        {
            var assemblyFailureState = await _manager.AssemblyFailureStateRepository.GetAllAssemblyFailureStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<AssemblyFailureStateDto>>(assemblyFailureState);
        }

        public async Task<IEnumerable<AssemblyFailureStateDto>> GetAllAssemblyFailureStateByManualAsync(int id, bool? trackChanges)
        {
            var assemblyFailureState = await _manager.AssemblyFailureStateRepository.GetAllAssemblyFailureStateByManualAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<AssemblyFailureStateDto>>(assemblyFailureState);
        }

        public async Task<IEnumerable<AssemblyFailureStateDto>> GetAllAssemblyFailureStateByQualityOfficerAsync(string userId, bool? trackChanges)
        {
            var assemblyFailureStates = await _manager.AssemblyFailureStateRepository.GetAllAssemblyFailureStateByQualityOfficerAsync(userId, trackChanges);
            return _mapper.Map<IEnumerable<AssemblyFailureStateDto>>(assemblyFailureStates);
        }

        public async Task<AssemblyFailureStateDto> GetAssemblyFailureStateByIdAsync(int id, bool? trackChanges)
        {
            var assemblyFailureState = await _manager.AssemblyFailureStateRepository.GetAssemblyFailureStateByIdAsync(id, trackChanges);
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureState);
        }

        public async Task<AssemblyFailureStateDto> UpdateAssemblyFailureByQualityStateAsync(AssemblyFailureStateDtoForQuality assemblyFailureStateDtoForQuality)
        {
            try
            {
                ConvertDatesToUtcQuality(assemblyFailureStateDtoForQuality);

                var assemblyFailureState = await _manager.AssemblyFailureStateRepository
                    .GetAssemblyFailureStateByIdAsync(assemblyFailureStateDtoForQuality.ID, false);

                var assemblyManual = await _manager.AssemblyManuelRepository
                    .GetAssemblyManuelByIdAsync(assemblyFailureState.AssemblyManuelID, false);

                if (assemblyManual.QualityOfficerID == assemblyFailureStateDtoForQuality.QualityOfficerID)
                {
                    assemblyFailureState.QualityOfficerDescription = assemblyFailureStateDtoForQuality.QualityOfficerDescription;
                    assemblyFailureState.QualityDescriptionDate = DateTime.UtcNow;
                    assemblyFailureState.QualityOfficerID = assemblyFailureStateDtoForQuality.QualityOfficerID;
                    _manager.AssemblyFailureStateRepository.UpdateAssemblyFailureByQualityState(assemblyFailureState);
                    await _manager.SaveAsync();
                    return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureState);
                }
                else
                {
                    throw new Exception("Kalite kontrolcüsü değilsiniz!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<AssemblyFailureStateDto> UpdateAssemblyFailureStateAsync(AssemblyFailureStateDtoForUpdate assemblyFailureStateDtoForUpdate)
        {
            var assemblyFailureState = await _manager.AssemblyFailureStateRepository.GetAssemblyFailureStateByIdAsync(assemblyFailureStateDtoForUpdate.ID, assemblyFailureStateDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(assemblyFailureStateDtoForUpdate);
            _mapper.Map(assemblyFailureStateDtoForUpdate, assemblyFailureState);
            _manager.AssemblyFailureStateRepository.UpdateAssemblyFailureState(assemblyFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyFailureStateDto>(assemblyFailureState);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : AssemblyFailureStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }

        private void ConvertDatesToUtcQuality<T>(T dto) where T : AssemblyFailureStateDtoForQuality
        {
            if (dto.QualityDescriptionDate.HasValue)
                dto.QualityDescriptionDate = DateTime.SpecifyKind(dto.QualityDescriptionDate.Value, DateTimeKind.Utc);
        }
    }
}
