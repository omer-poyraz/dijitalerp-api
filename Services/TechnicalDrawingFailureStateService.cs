using AutoMapper;
using Entities.DTOs.TechnicalDrawingFailureStateDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TechnicalDrawingFailureStateService : ITechnicalDrawingFailureStateService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public TechnicalDrawingFailureStateService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<TechnicalDrawingFailureStateDto> CreateTechnicalDrawingFailureStateAsync(TechnicalDrawingFailureStateDtoForInsertion technicalDrawingFailureStateGroupDtoForInsertion)
        {
            var technicalDrawingFailureStateGroup = _mapper.Map<TechnicalDrawingFailureState>(technicalDrawingFailureStateGroupDtoForInsertion);
            ConvertDatesToUtc(technicalDrawingFailureStateGroupDtoForInsertion);
            _manager.TechnicalDrawingFailureStateRepository.CreateTechnicalDrawingFailureState(technicalDrawingFailureStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureStateGroup);
        }

        public async Task<TechnicalDrawingFailureStateDto> DeleteTechnicalDrawingFailureStateAsync(int id, bool? trackChanges)
        {
            var technicalDrawingFailureStateGroup = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync(id, trackChanges);
            _manager.TechnicalDrawingFailureStateRepository.DeleteTechnicalDrawingFailureState(technicalDrawingFailureStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureStateGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingFailureStateDto>> GetAllTechnicalDrawingFailureStateAsync(bool? trackChanges)
        {
            var technicalDrawingFailureStateGroup = await _manager.TechnicalDrawingFailureStateRepository.GetAllTechnicalDrawingFailureStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingFailureStateDto>>(technicalDrawingFailureStateGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingFailureStateDto>> GetAllTechnicalDrawingFailureStateByDrawingAsync(int id, bool? trackChanges)
        {
            var technicalDrawingFailureStateGroup = await _manager.TechnicalDrawingFailureStateRepository.GetAllTechnicalDrawingFailureStateByDrawingAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingFailureStateDto>>(technicalDrawingFailureStateGroup);
        }

        public async Task<TechnicalDrawingFailureStateDto> GetTechnicalDrawingFailureStateByIdAsync(int id, bool? trackChanges)
        {
            var technicalDrawingFailureStateGroup = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync(id, trackChanges);
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureStateGroup);
        }

        public async Task<TechnicalDrawingFailureStateDto> UpdateTechnicalDrawingFailureStateAsync(TechnicalDrawingFailureStateDtoForUpdate technicalDrawingFailureStateGroupDtoForUpdate)
        {
            var technicalDrawingFailureStateGroup = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync(technicalDrawingFailureStateGroupDtoForUpdate.ID, technicalDrawingFailureStateGroupDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(technicalDrawingFailureStateGroupDtoForUpdate);
            _mapper.Map(technicalDrawingFailureStateGroupDtoForUpdate, technicalDrawingFailureStateGroup);
            _manager.TechnicalDrawingFailureStateRepository.UpdateTechnicalDrawingFailureState(technicalDrawingFailureStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureStateGroup);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : TechnicalDrawingFailureStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }
    }
}
