using AutoMapper;
using Entities.DTOs.AssemblyVisualNoteDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AssemblyVisualNoteService : IAssemblyVisualNoteService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AssemblyVisualNoteService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<AssemblyVisualNoteDto> CreateAssemblyVisualNoteAsync(AssemblyVisualNoteDtoForInsertion assemblyVisualNoteDtoForInsertion)
        {
            try
            {
                var assemblyVisualNote = _mapper.Map<AssemblyVisualNote>(assemblyVisualNoteDtoForInsertion);
                _manager.AssemblyVisualNoteRepository.CreateAssemblyVisualNote(assemblyVisualNote);
                await _manager.SaveAsync();
                return _mapper.Map<AssemblyVisualNoteDto>(assemblyVisualNote);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<AssemblyVisualNoteDto> DeleteAssemblyVisualNoteAsync(int id, bool? trackChanges)
        {
            var assemblyVisualNote = await _manager.AssemblyVisualNoteRepository.GetAssemblyVisualNoteByIdAsync(id, trackChanges);
            _manager.AssemblyVisualNoteRepository.DeleteAssemblyVisualNote(assemblyVisualNote);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyVisualNoteDto>(assemblyVisualNote);
        }

        public async Task<IEnumerable<AssemblyVisualNoteDto>> GetAllAssemblyVisualNoteAsync(bool? trackChanges)
        {
            var assemblyVisualNote = await _manager.AssemblyVisualNoteRepository.GetAllAssemblyVisualNoteAsync(trackChanges);
            return _mapper.Map<IEnumerable<AssemblyVisualNoteDto>>(assemblyVisualNote);
        }

        public async Task<AssemblyVisualNoteDto> GetAssemblyVisualNoteByIdAsync(int id, bool? trackChanges)
        {
            var assemblyVisualNote = await _manager.AssemblyVisualNoteRepository.GetAssemblyVisualNoteByIdAsync(id, trackChanges);
            return _mapper.Map<AssemblyVisualNoteDto>(assemblyVisualNote);
        }

        public async Task<IEnumerable<AssemblyVisualNoteDto>> GetAllAssemblyVisualNoteByDrawingAsync(int id, bool? trackChanges)
        {
            var assemblyVisualNote = await _manager.AssemblyVisualNoteRepository.GetAllAssemblyVisualNoteByDrawingAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<AssemblyVisualNoteDto>>(assemblyVisualNote);
        }
    }
}
