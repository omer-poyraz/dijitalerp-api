using AutoMapper;
using Entities.DTOs.TechnicalDrawingQualityDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TechnicalDrawingQualityService : ITechnicalDrawingQualityService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public TechnicalDrawingQualityService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<TechnicalDrawingQualityDto> CreateTechnicalDrawingQualityAsync(TechnicalDrawingQualityDtoForInsertion technicalDrawingQualityDtoForInsertion)
        {
            var technicalDrawingQuality = _mapper.Map<TechnicalDrawingQuality>(technicalDrawingQualityDtoForInsertion);
            var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync((int)technicalDrawingQuality.TechnicalDrawingFailureStateID!, false);
            var technicalDrawingManual = await _manager.TechnicalDrawingRepository.GetTechnicalDrawingByIdAsync((int)technicalDrawingFailureState.TechnicalDrawingID!, false);
            if (technicalDrawingQualityDtoForInsertion.UserId == null)
            {
                throw new Exception("Kalite sorumlusu giriniz!");
            }
            if (technicalDrawingQualityDtoForInsertion.UserId == technicalDrawingManual.QualityOfficerID)
            {
                _manager.TechnicalDrawingQualityRepository.CreateTechnicalDrawingQuality(technicalDrawingQuality);
                await _manager.SaveAsync();
                return _mapper.Map<TechnicalDrawingQualityDto>(technicalDrawingQuality);
            }
            else
            {
                throw new Exception("Yalnızca kalite sorumlusu not bırakabilir!");
            }
        }

        public async Task<TechnicalDrawingQualityDto> DeleteTechnicalDrawingQualityAsync(int id, bool? trackChanges)
        {
            var technicalDrawingQualityGroup = await _manager.TechnicalDrawingQualityRepository.GetTechnicalDrawingQualityByIdAsync(id, trackChanges);
            _manager.TechnicalDrawingQualityRepository.DeleteTechnicalDrawingQuality(technicalDrawingQualityGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingQualityDto>(technicalDrawingQualityGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingQualityDto>> GetAllTechnicalDrawingQualityAsync(bool? trackChanges)
        {
            var technicalDrawingQualityGroup = await _manager.TechnicalDrawingQualityRepository.GetAllTechnicalDrawingQualityAsync(trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingQualityDto>>(technicalDrawingQualityGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingQualityDto>> GetAllTechnicalDrawingQualityByFailureAsync(int id, bool? trackChanges)
        {
            var technicalDrawingQualityGroup = await _manager.TechnicalDrawingQualityRepository.GetAllTechnicalDrawingQualityByFailureAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingQualityDto>>(technicalDrawingQualityGroup);
        }

        public async Task<TechnicalDrawingQualityDto> GetTechnicalDrawingQualityByIdAsync(int id, bool? trackChanges)
        {
            var technicalDrawingQualityGroup = await _manager.TechnicalDrawingQualityRepository.GetTechnicalDrawingQualityByIdAsync(id, trackChanges);
            return _mapper.Map<TechnicalDrawingQualityDto>(technicalDrawingQualityGroup);
        }

        public async Task<TechnicalDrawingQualityDto> UpdateTechnicalDrawingQualityAsync(TechnicalDrawingQualityDtoForUpdate technicalDrawingQualityDtoForUpdate)
        {
            var technicalDrawingQuality = await _manager.TechnicalDrawingQualityRepository.GetTechnicalDrawingQualityByIdAsync(technicalDrawingQualityDtoForUpdate.ID, technicalDrawingQualityDtoForUpdate.TrackChanges);
            var technicalDrawingFailureState = await _manager.TechnicalDrawingFailureStateRepository.GetTechnicalDrawingFailureStateByIdAsync((int)technicalDrawingQuality.TechnicalDrawingFailureStateID!, false);
            var technicalDrawingManual = await _manager.TechnicalDrawingRepository.GetTechnicalDrawingByIdAsync((int)technicalDrawingFailureState.TechnicalDrawingID!, false);
            _mapper.Map(technicalDrawingQualityDtoForUpdate, technicalDrawingQuality);
            if (technicalDrawingQualityDtoForUpdate.UserId == null)
            {
                throw new Exception("Kalite sorumlusu giriniz!");
            }
            if (technicalDrawingQualityDtoForUpdate.UserId == technicalDrawingManual.QualityOfficerID)
            {
                _manager.TechnicalDrawingQualityRepository.UpdateTechnicalDrawingQuality(technicalDrawingQuality);
                await _manager.SaveAsync();
                return _mapper.Map<TechnicalDrawingQualityDto>(technicalDrawingQuality);
            }
            else
            {
                throw new Exception("Yalnızca kalite sorumlusu not güncelleyebilir!");
            }
        }
    }
}
