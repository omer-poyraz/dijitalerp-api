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

        public async Task<TechnicalDrawingFailureStateDto> CreateTechnicalDrawingFailureStateAsync(TechnicalDrawingFailureStateDtoForInsertion technicalDrawingFailureStateDtoForInsertion)
        {
            var technicalDrawingFailureState = _mapper.Map<TechnicalDrawingFailureState>(technicalDrawingFailureStateDtoForInsertion);
            ConvertDatesToUtc(technicalDrawingFailureStateDtoForInsertion);
            _manager.TechnicalDrawingFailureStateRepository.CreateTechnicalDrawingFailureState(technicalDrawingFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureState);
        }

        public async Task<TechnicalDrawingFailureStateDto> DeleteTechnicalDrawingFailureStateAsync(int id, bool? trackChanges)
        {
            var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync(id, trackChanges);
            _manager.TechnicalDrawingFailureStateRepository.DeleteTechnicalDrawingFailureState(technicalDrawingFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureState);
        }

        public async Task<IEnumerable<TechnicalDrawingFailureStateDto>> GetAllTechnicalDrawingFailureStateAsync(bool? trackChanges)
        {
            var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetAllTechnicalDrawingFailureStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingFailureStateDto>>(technicalDrawingFailureState);
        }

        public async Task<IEnumerable<TechnicalDrawingFailureStateDto>> GetAllTechnicalDrawingFailureStateByDrawingAsync(int id, bool? trackChanges)
        {
            var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetAllTechnicalDrawingFailureStateByDrawingAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingFailureStateDto>>(technicalDrawingFailureState);
        }

        public async Task<TechnicalDrawingFailureStateDto> GetTechnicalDrawingFailureStateByIdAsync(int id, bool? trackChanges)
        {
            var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync(id, trackChanges);
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureState);
        }

        public async Task<TechnicalDrawingFailureStateDto> UpdateTechnicalDrawingFailureByQualityStateAsync(TechnicalDrawingFailureStateDtoForQuality technicalDrawingFailureStateDtoForQuality)
        {
            try
            {
                ConvertDatesToUtcQuality(technicalDrawingFailureStateDtoForQuality);
                var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync(technicalDrawingFailureStateDtoForQuality.ID, false);
                var technicalDrawing = await _manager.TechnicalDrawingRepository.GetTechnicalDrawingByIdAsync((int)technicalDrawingFailureState.TechnicalDrawingID!, false);

                if (technicalDrawing.QualityOfficerID == technicalDrawingFailureStateDtoForQuality.QualityOfficerID)
                {
                    technicalDrawingFailureState.QualityOfficerDescription = technicalDrawingFailureStateDtoForQuality.QualityOfficerDescription;
                    technicalDrawingFailureState.QualityDescriptionDate = DateTime.UtcNow;
                    technicalDrawingFailureState.QualityOfficerID = technicalDrawingFailureStateDtoForQuality.QualityOfficerID;
                    _manager.TechnicalDrawingFailureStateRepository.UpdateTechnicalDrawingFailureByQualityState(technicalDrawingFailureState);
                    await _manager.SaveAsync();
                    return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureState);
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

        public async Task<TechnicalDrawingFailureStateDto> UpdateTechnicalDrawingFailureStateAsync(TechnicalDrawingFailureStateDtoForUpdate technicalDrawingFailureStateDtoForUpdate)
        {
            var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync(technicalDrawingFailureStateDtoForUpdate.ID, technicalDrawingFailureStateDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(technicalDrawingFailureStateDtoForUpdate);
            _mapper.Map(technicalDrawingFailureStateDtoForUpdate, technicalDrawingFailureState);
            _manager.TechnicalDrawingFailureStateRepository.UpdateTechnicalDrawingFailureState(technicalDrawingFailureState);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingFailureStateDto>(technicalDrawingFailureState);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : TechnicalDrawingFailureStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }

        private void ConvertDatesToUtcQuality<T>(T dto) where T : TechnicalDrawingFailureStateDtoForQuality
        {
            if (dto.QualityDescriptionDate.HasValue)
                dto.QualityDescriptionDate = DateTime.SpecifyKind(dto.QualityDescriptionDate.Value, DateTimeKind.Utc);
        }
    }
}
