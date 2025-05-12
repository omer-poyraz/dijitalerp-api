using AutoMapper;
using Entities.DTOs.CMMNoteDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CMMNoteService : ICMMNoteService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CMMNoteService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CMMNoteDto> CreateCMMNoteAsync(CMMNoteDtoForInsertion cmmNoteGroupDtoForInsertion)
        {
            var cmmNoteGroup = _mapper.Map<CMMNote>(cmmNoteGroupDtoForInsertion);
            if (cmmNoteGroupDtoForInsertion.Status != true)
            {
                _manager.CMMSuccessStateRepository.CreateCMMSuccessState(new CMMSuccessState
                {
                    CMMID = cmmNoteGroup.CMMID,
                    Description = cmmNoteGroup.Description,
                    PartCode = cmmNoteGroup.PartCode,
                    Status = cmmNoteGroup.Status,
                    UserId = cmmNoteGroup.UserId,
                    CreatedAt = DateTime.UtcNow
                });
            }
            else
            {
                _manager.CMMFailureStateRepository.CreateCMMFailureState(new CMMFailureState
                {
                    CMMID = cmmNoteGroup.CMMID,
                    PartCode = cmmNoteGroup.PartCode,
                    Description = cmmNoteGroup.Description,
                    Status = cmmNoteGroup.Status,
                    UserId = cmmNoteGroup.UserId,
                    CreatedAt = DateTime.UtcNow
                });
            }
            _manager.CMMNoteRepository.CreateCMMNote(cmmNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<CMMNoteDto>(cmmNoteGroup);
        }

        public async Task<CMMNoteDto> DeleteCMMNoteAsync(int id, bool? trackChanges)
        {
            var cmmNoteGroup = await _manager.CMMNoteRepository.GetCMMNoteByIdAsync(id, trackChanges);
            _manager.CMMNoteRepository.DeleteCMMNote(cmmNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<CMMNoteDto>(cmmNoteGroup);
        }

        public async Task<IEnumerable<CMMNoteDto>> GetAllCMMNoteAsync(bool? trackChanges)
        {
            var cmmNoteGroup = await _manager.CMMNoteRepository.GetAllCMMNoteAsync(trackChanges);
            return _mapper.Map<IEnumerable<CMMNoteDto>>(cmmNoteGroup);
        }

        public async Task<IEnumerable<CMMNoteDto>> GetAllCMMNoteByManualAsync(int id, bool? trackChanges)
        {
            var cmmNoteGroup = await _manager.CMMNoteRepository.GetAllCMMNoteByManualAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<CMMNoteDto>>(cmmNoteGroup);
        }

        public async Task<CMMNoteDto> GetCMMNoteByIdAsync(int id, bool? trackChanges)
        {
            var cmmNoteGroup = await _manager.CMMNoteRepository.GetCMMNoteByIdAsync(id, trackChanges);
            return _mapper.Map<CMMNoteDto>(cmmNoteGroup);
        }

        public async Task<CMMNoteDto> UpdateCMMNoteAsync(CMMNoteDtoForUpdate cmmNoteGroupDtoForUpdate)
        {
            var cmmNoteGroup = await _manager.CMMNoteRepository.GetCMMNoteByIdAsync(cmmNoteGroupDtoForUpdate.ID, cmmNoteGroupDtoForUpdate.TrackChanges);
            _mapper.Map(cmmNoteGroupDtoForUpdate, cmmNoteGroup);
            _manager.CMMNoteRepository.UpdateCMMNote(cmmNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<CMMNoteDto>(cmmNoteGroup);
        }
    }
}
