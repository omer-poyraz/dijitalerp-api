using AutoMapper;
using Entities.DTOs.TechnicalDrawingSuccessStateDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TechnicalDrawingSuccessStateService : ITechnicalDrawingSuccessStateService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public TechnicalDrawingSuccessStateService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<TechnicalDrawingSuccessStateDto> CreateTechnicalDrawingSuccessStateAsync(TechnicalDrawingSuccessStateDtoForInsertion technicalDrawingSuccessStateGroupDtoForInsertion)
        {
            try
            {
                var technicalDrawingSuccessStateGroup = _mapper.Map<TechnicalDrawingSuccessState>(technicalDrawingSuccessStateGroupDtoForInsertion);
                ConvertDatesToUtc(technicalDrawingSuccessStateGroupDtoForInsertion);
                _manager.TechnicalDrawingSuccessStateRepository.CreateTechnicalDrawingSuccessState(technicalDrawingSuccessStateGroup);
                await _manager.SaveAsync();
                return _mapper.Map<TechnicalDrawingSuccessStateDto>(technicalDrawingSuccessStateGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<TechnicalDrawingSuccessStateDto> DeleteTechnicalDrawingSuccessStateAsync(int id, bool? trackChanges)
        {
            var technicalDrawingSuccessStateGroup = await _manager.TechnicalDrawingSuccessStateRepository.GetTechnicalDrawingSuccessStateByIdAsync(id, trackChanges);
            _manager.TechnicalDrawingSuccessStateRepository.DeleteTechnicalDrawingSuccessState(technicalDrawingSuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingSuccessStateDto>(technicalDrawingSuccessStateGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingSuccessStateDto>> GetAllTechnicalDrawingSuccessStateAsync(bool? trackChanges)
        {
            var technicalDrawingSuccessStateGroup = await _manager.TechnicalDrawingSuccessStateRepository.GetAllTechnicalDrawingSuccessStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingSuccessStateDto>>(technicalDrawingSuccessStateGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingSuccessStateDto>> GetAllTechnicalDrawingSuccessStateByDrawingAsync(int id, bool? trackChanges)
        {
            var technicalDrawingSuccessStateGroup = await _manager.TechnicalDrawingSuccessStateRepository.GetAllTechnicalDrawingSuccessStateByDrawingAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingSuccessStateDto>>(technicalDrawingSuccessStateGroup);
        }

        public async Task<TechnicalDrawingSuccessStateDto> GetTechnicalDrawingSuccessStateByIdAsync(int id, bool? trackChanges)
        {
            var technicalDrawingSuccessStateGroup = await _manager.TechnicalDrawingSuccessStateRepository.GetTechnicalDrawingSuccessStateByIdAsync(id, trackChanges);
            return _mapper.Map<TechnicalDrawingSuccessStateDto>(technicalDrawingSuccessStateGroup);
        }

        public async Task<TechnicalDrawingSuccessStateDto> UpdateTechnicalDrawingSuccessStateAsync(TechnicalDrawingSuccessStateDtoForUpdate technicalDrawingSuccessStateGroupDtoForUpdate)
        {
            var technicalDrawingSuccessStateGroup = await _manager.TechnicalDrawingSuccessStateRepository.GetTechnicalDrawingSuccessStateByIdAsync(technicalDrawingSuccessStateGroupDtoForUpdate.ID, technicalDrawingSuccessStateGroupDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(technicalDrawingSuccessStateGroupDtoForUpdate);
            _mapper.Map(technicalDrawingSuccessStateGroupDtoForUpdate, technicalDrawingSuccessStateGroup);
            _manager.TechnicalDrawingSuccessStateRepository.UpdateTechnicalDrawingSuccessState(technicalDrawingSuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingSuccessStateDto>(technicalDrawingSuccessStateGroup);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : TechnicalDrawingSuccessStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }
    }
}
