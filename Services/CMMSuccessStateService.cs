using AutoMapper;
using Entities.DTOs.CMMSuccessStateDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CMMSuccessStateService : ICMMSuccessStateService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CMMSuccessStateService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CMMSuccessStateDto> CreateCMMSuccessStateAsync(
            CMMSuccessStateDtoForInsertion cmmSuccessStateGroupDtoForInsertion
        )
        {
            try
            {
                var cmmSuccessStateGroup = _mapper.Map<CMMSuccessState>(cmmSuccessStateGroupDtoForInsertion);
                ConvertDatesToUtc(cmmSuccessStateGroupDtoForInsertion);
                _manager.CMMSuccessStateRepository.CreateCMMSuccessState(cmmSuccessStateGroup);
                await _manager.SaveAsync();
                return _mapper.Map<CMMSuccessStateDto>(cmmSuccessStateGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<CMMSuccessStateDto> DeleteCMMSuccessStateAsync(int id, bool? trackChanges)
        {
            var cmmSuccessStateGroup = await _manager.CMMSuccessStateRepository.GetCMMSuccessStateByIdAsync(id, trackChanges);
            _manager.CMMSuccessStateRepository.DeleteCMMSuccessState(cmmSuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<CMMSuccessStateDto>(cmmSuccessStateGroup);
        }

        public async Task<IEnumerable<CMMSuccessStateDto>> GetAllCMMSuccessStateAsync(bool? trackChanges)
        {
            var cmmSuccessStateGroup = await _manager.CMMSuccessStateRepository.GetAllCMMSuccessStateAsync(trackChanges);
            return _mapper.Map<IEnumerable<CMMSuccessStateDto>>(cmmSuccessStateGroup);
        }

        public async Task<IEnumerable<CMMSuccessStateDto>> GetAllCMMSuccessStateByManualAsync(int id, bool? trackChanges)
        {
            var cmmSuccessStateGroup = await _manager.CMMSuccessStateRepository.GetAllCMMSuccessStateByManualAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<CMMSuccessStateDto>>(cmmSuccessStateGroup);
        }

        public async Task<CMMSuccessStateDto> GetCMMSuccessStateByIdAsync(int id, bool? trackChanges)
        {
            var cmmSuccessStateGroup = await _manager.CMMSuccessStateRepository.GetCMMSuccessStateByIdAsync(id, trackChanges);
            return _mapper.Map<CMMSuccessStateDto>(cmmSuccessStateGroup);
        }

        public async Task<CMMSuccessStateDto> UpdateCMMSuccessStateAsync(CMMSuccessStateDtoForUpdate cmmSuccessStateGroupDtoForUpdate)
        {
            var cmmSuccessStateGroup = await _manager.CMMSuccessStateRepository.GetCMMSuccessStateByIdAsync(cmmSuccessStateGroupDtoForUpdate.ID, cmmSuccessStateGroupDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(cmmSuccessStateGroupDtoForUpdate);
            _mapper.Map(cmmSuccessStateGroupDtoForUpdate, cmmSuccessStateGroup);
            _manager.CMMSuccessStateRepository.UpdateCMMSuccessState(cmmSuccessStateGroup);
            await _manager.SaveAsync();
            return _mapper.Map<CMMSuccessStateDto>(cmmSuccessStateGroup);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : CMMSuccessStateDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);
        }
    }
}
