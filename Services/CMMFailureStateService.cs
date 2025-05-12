using AutoMapper;
using Entities.DTOs.CMMFailureStateDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CMMFailureStateService : ICMMFailureStateService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CMMFailureStateService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CMMFailureStateDto> CreateCMMFailureStateAsync(
            CMMFailureStateDtoForInsertion cmmFailureStateDtoForInsertion
        )
        {
            var cmmFailureState = _mapper.Map<CMMFailureState>(cmmFailureStateDtoForInsertion);
            ConvertDatesToUtc(cmmFailureStateDtoForInsertion);
            _manager.CMMFailureStateRepository.CreateCMMFailureState(cmmFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<CMMFailureStateDto>(cmmFailureState);
        }

        public async Task<CMMFailureStateDto> DeleteCMMFailureStateAsync(int id, bool? trackChanges)
        {
            var cmmFailureState = await _manager.CMMFailureStateRepository.GetCMMFailureStateByIdAsync(id, trackChanges);
            _manager.CMMFailureStateRepository.DeleteCMMFailureState(cmmFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<CMMFailureStateDto>(cmmFailureState);
        }

        public async Task<IEnumerable<CMMFailureStateDto>> GetAllCMMFailureStateAsync(bool? trackChanges)
        {
            var cmmFailureState = await _manager.CMMFailureStateRepository.GetAllCMMFailureStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<CMMFailureStateDto>>(cmmFailureState);
        }

        public async Task<IEnumerable<CMMFailureStateDto>> GetAllCMMFailureStateByManualAsync(int id, bool? trackChanges)
        {
            var cmmFailureState = await _manager.CMMFailureStateRepository.GetAllCMMFailureStateByManualAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<CMMFailureStateDto>>(cmmFailureState);
        }

        public async Task<CMMFailureStateDto> GetCMMFailureStateByIdAsync(int id, bool? trackChanges)
        {
            var cmmFailureState = await _manager.CMMFailureStateRepository.GetCMMFailureStateByIdAsync(id, trackChanges);
            return _mapper.Map<CMMFailureStateDto>(cmmFailureState);
        }

        public async Task<CMMFailureStateDto> UpdateCMMFailureStateAsync(CMMFailureStateDtoForUpdate cmmFailureStateDtoForUpdate)
        {
            var cmmFailureState = await _manager.CMMFailureStateRepository.GetCMMFailureStateByIdAsync(cmmFailureStateDtoForUpdate.ID, cmmFailureStateDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(cmmFailureStateDtoForUpdate);
            _mapper.Map(cmmFailureStateDtoForUpdate, cmmFailureState);
            _manager.CMMFailureStateRepository.UpdateCMMFailureState(cmmFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<CMMFailureStateDto>(cmmFailureState);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : CMMFailureStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }
    }
}
