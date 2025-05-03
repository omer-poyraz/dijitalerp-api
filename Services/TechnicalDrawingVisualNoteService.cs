using AutoMapper;
using Entities.DTOs.TechnicalDrawingVisualNoteDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TechnicalDrawingVisualNoteService : ITechnicalDrawingVisualNoteService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public TechnicalDrawingVisualNoteService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<TechnicalDrawingVisualNoteDto> CreateTechnicalDrawingVisualNoteAsync(TechnicalDrawingVisualNoteDtoForInsertion technicalDrawingVisualNoteDtoForInsertion)
        {
            try
            {
                var technicalDrawingVisualNote = _mapper.Map<TechnicalDrawingVisualNote>(technicalDrawingVisualNoteDtoForInsertion);
                _manager.TechnicalDrawingVisualNoteRepository.CreateTechnicalDrawingVisualNote(technicalDrawingVisualNote);
                await _manager.SaveAsync();
                return _mapper.Map<TechnicalDrawingVisualNoteDto>(technicalDrawingVisualNote);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<TechnicalDrawingVisualNoteDto> DeleteTechnicalDrawingVisualNoteAsync(int id, bool? trackChanges)
        {
            var technicalDrawingVisualNote = await _manager.TechnicalDrawingVisualNoteRepository.GetTechnicalDrawingVisualNoteByIdAsync(id, trackChanges);
            _manager.TechnicalDrawingVisualNoteRepository.DeleteTechnicalDrawingVisualNote(technicalDrawingVisualNote);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingVisualNoteDto>(technicalDrawingVisualNote);
        }

        public async Task<IEnumerable<TechnicalDrawingVisualNoteDto>> GetAllTechnicalDrawingVisualNoteAsync(bool? trackChanges)
        {
            var technicalDrawingVisualNote = await _manager.TechnicalDrawingVisualNoteRepository.GetAllTechnicalDrawingVisualNoteAsync(trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingVisualNoteDto>>(technicalDrawingVisualNote);
        }

        public async Task<TechnicalDrawingVisualNoteDto> GetTechnicalDrawingVisualNoteByIdAsync(int id, bool? trackChanges)
        {
            var technicalDrawingVisualNote = await _manager.TechnicalDrawingVisualNoteRepository.GetTechnicalDrawingVisualNoteByIdAsync(id, trackChanges);
            return _mapper.Map<TechnicalDrawingVisualNoteDto>(technicalDrawingVisualNote);
        }

        public async Task<IEnumerable<TechnicalDrawingVisualNoteDto>> GetAllTechnicalDrawingVisualNoteByDrawingAsync(int id, bool? trackChanges)
        {
            var technicalDrawingVisualNote = await _manager.TechnicalDrawingVisualNoteRepository.GetAllTechnicalDrawingVisualNoteByDrawingAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingVisualNoteDto>>(technicalDrawingVisualNote);
        }
    }
}
