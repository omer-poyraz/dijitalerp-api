using AutoMapper;
using Entities.DTOs.TechnicalDrawingNoteDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TechnicalDrawingNoteService : ITechnicalDrawingNoteService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public TechnicalDrawingNoteService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<TechnicalDrawingNoteDto> CreateTechnicalDrawingNoteAsync(TechnicalDrawingNoteDtoForInsertion technicalDrawingNoteGroupDtoForInsertion)
        {
            var technicalDrawingNoteGroup = _mapper.Map<TechnicalDrawingNote>(technicalDrawingNoteGroupDtoForInsertion);
            if (technicalDrawingNoteGroupDtoForInsertion.Status != true)
            {
                _manager.TechnicalDrawingSuccessStateRepository.CreateTechnicalDrawingSuccessState(new TechnicalDrawingSuccessState
                {
                    TechnicalDrawingID = technicalDrawingNoteGroup.TechnicalDrawingID,
                    Description = technicalDrawingNoteGroup.Description,
                    PartCode = technicalDrawingNoteGroup.PartCode,
                    Status = technicalDrawingNoteGroup.Status,
                    UserId = technicalDrawingNoteGroup.UserId,
                    CreatedAt = DateTime.UtcNow
                });
            }
            else
            {
                _manager.TechnicalDrawingFailureStateRepository.CreateTechnicalDrawingFailureState(new TechnicalDrawingFailureState
                {
                    TechnicalDrawingID = technicalDrawingNoteGroup.TechnicalDrawingID,
                    PartCode = technicalDrawingNoteGroup.PartCode,
                    Description = technicalDrawingNoteGroup.Description,
                    Status = technicalDrawingNoteGroup.Status,
                    UserId = technicalDrawingNoteGroup.UserId,
                    CreatedAt = DateTime.UtcNow
                });
            }
            _manager.TechnicalDrawingNoteRepository.CreateTechnicalDrawingNote(technicalDrawingNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingNoteDto>(technicalDrawingNoteGroup);
        }

        public async Task<TechnicalDrawingNoteDto> DeleteTechnicalDrawingNoteAsync(int id, bool? trackChanges)
        {
            var technicalDrawingNoteGroup = await _manager.TechnicalDrawingNoteRepository.GetTechnicalDrawingNoteByIdAsync(id, trackChanges);
            _manager.TechnicalDrawingNoteRepository.DeleteTechnicalDrawingNote(technicalDrawingNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingNoteDto>(technicalDrawingNoteGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingNoteDto>> GetAllTechnicalDrawingNoteAsync(bool? trackChanges)
        {
            var technicalDrawingNoteGroup = await _manager.TechnicalDrawingNoteRepository.GetAllTechnicalDrawingNoteAsync(trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingNoteDto>>(technicalDrawingNoteGroup);
        }

        public async Task<IEnumerable<TechnicalDrawingNoteDto>> GetAllTechnicalDrawingNoteByDrawingAsync(int id, bool? trackChanges)
        {
            var technicalDrawingNoteGroup = await _manager.TechnicalDrawingNoteRepository.GetAllTechnicalDrawingNoteByDrawingAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingNoteDto>>(technicalDrawingNoteGroup);
        }

        public async Task<TechnicalDrawingNoteDto> GetTechnicalDrawingNoteByIdAsync(int id, bool? trackChanges)
        {
            var technicalDrawingNoteGroup = await _manager.TechnicalDrawingNoteRepository.GetTechnicalDrawingNoteByIdAsync(id, trackChanges);
            return _mapper.Map<TechnicalDrawingNoteDto>(technicalDrawingNoteGroup);
        }

        public async Task<TechnicalDrawingNoteDto> UpdateTechnicalDrawingNoteAsync(TechnicalDrawingNoteDtoForUpdate technicalDrawingNoteGroupDtoForUpdate)
        {
            var technicalDrawingNoteGroup = await _manager.TechnicalDrawingNoteRepository.GetTechnicalDrawingNoteByIdAsync(technicalDrawingNoteGroupDtoForUpdate.ID, technicalDrawingNoteGroupDtoForUpdate.TrackChanges);
            _mapper.Map(technicalDrawingNoteGroupDtoForUpdate, technicalDrawingNoteGroup);
            _manager.TechnicalDrawingNoteRepository.UpdateTechnicalDrawingNote(technicalDrawingNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingNoteDto>(technicalDrawingNoteGroup);
        }
    }
}
