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

        public async Task<CMMFailureStateDto> UpdateCMMFailureByQualityStateAsync(CMMFailureStateDtoForQuality cmmFailureStateDtoForQuality)
        {
            try
            {
                ConvertDatesToUtcQuality(cmmFailureStateDtoForQuality);

                var cmmFailureState = await _manager.CMMFailureStateRepository
                    .GetCMMFailureStateByIdAsync(cmmFailureStateDtoForQuality.ID, false);

                var cmm = await _manager.CMMRepository
                    .GetCMMByIdAsync(cmmFailureState.CMMID, false);

                if (cmm.QualityOfficerID == cmmFailureStateDtoForQuality.QualityOfficerID)
                {
                    cmmFailureState.QualityOfficerDescription = cmmFailureStateDtoForQuality.QualityOfficerDescription;
                    cmmFailureState.QualityDescriptionDate = DateTime.UtcNow;
                    cmmFailureState.QualityOfficerID = cmmFailureStateDtoForQuality.QualityOfficerID;
                    _manager.CMMFailureStateRepository.UpdateCMMFailureByQualityState(cmmFailureState);
                    await _manager.SaveAsync();
                    return _mapper.Map<CMMFailureStateDto>(cmmFailureState);
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

        private void ConvertDatesToUtcQuality<T>(T dto) where T : CMMFailureStateDtoForQuality
        {
            if (dto.QualityDescriptionDate.HasValue)
                dto.QualityDescriptionDate = DateTime.SpecifyKind(dto.QualityDescriptionDate.Value, DateTimeKind.Utc);
        }
    }
}
