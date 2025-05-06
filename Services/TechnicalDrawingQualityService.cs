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

        public async Task<TechnicalDrawingQualityDto> CreateTechnicalDrawingQualityAsync(TechnicalDrawingQualityDtoForInsertion technicalDrawingQualityGroupDtoForInsertion)
        {
            var technicalDrawingQualityGroup = _mapper.Map<TechnicalDrawingQuality>(technicalDrawingQualityGroupDtoForInsertion);
            _manager.TechnicalDrawingQualityRepository.CreateTechnicalDrawingQuality(technicalDrawingQualityGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingQualityDto>(technicalDrawingQualityGroup);
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

        public async Task<TechnicalDrawingQualityDto> UpdateTechnicalDrawingQualityAsync(TechnicalDrawingQualityDtoForUpdate technicalDrawingQualityGroupDtoForUpdate)
        {
            var technicalDrawingQualityGroup = await _manager.TechnicalDrawingQualityRepository.GetTechnicalDrawingQualityByIdAsync(technicalDrawingQualityGroupDtoForUpdate.ID, technicalDrawingQualityGroupDtoForUpdate.TrackChanges);
            _mapper.Map(technicalDrawingQualityGroupDtoForUpdate, technicalDrawingQualityGroup);
            _manager.TechnicalDrawingQualityRepository.UpdateTechnicalDrawingQuality(technicalDrawingQualityGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingQualityDto>(technicalDrawingQualityGroup);
        }
    }
}
