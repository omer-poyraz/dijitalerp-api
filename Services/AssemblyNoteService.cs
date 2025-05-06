using AutoMapper;
using Entities.DTOs.AssemblyNoteDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AssemblyNoteService : IAssemblyNoteService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AssemblyNoteService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<AssemblyNoteDto> CreateAssemblyNoteAsync(AssemblyNoteDtoForInsertion assemblyNoteGroupDtoForInsertion)
        {
            var assemblyNoteGroup = _mapper.Map<AssemblyNote>(assemblyNoteGroupDtoForInsertion);
            if (assemblyNoteGroupDtoForInsertion.Status == true)
            {
                _manager.AssemblySuccessStateRepository.CreateAssemblySuccessState(new AssemblySuccessState
                {
                    AssemblyManuelID = assemblyNoteGroup.AssemblyManuelID,
                    Description = assemblyNoteGroup.Description,
                    PartCode = assemblyNoteGroup.PartCode,
                    Status = assemblyNoteGroup.Status,
                    UserId = assemblyNoteGroup.UserId,
                    CreatedAt = DateTime.UtcNow
                });
            }
            else
            {
                _manager.AssemblyFailureStateRepository.CreateAssemblyFailureState(new AssemblyFailureState
                {
                    AssemblyManuelID = assemblyNoteGroup.AssemblyManuelID,
                    PartCode = assemblyNoteGroup.PartCode,
                    Description = assemblyNoteGroup.Description,
                    Status = assemblyNoteGroup.Status,
                    UserId = assemblyNoteGroup.UserId,
                    CreatedAt = DateTime.UtcNow
                });
            }
            _manager.AssemblyNoteRepository.CreateAssemblyNote(assemblyNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyNoteDto>(assemblyNoteGroup);
        }

        public async Task<AssemblyNoteDto> DeleteAssemblyNoteAsync(int id, bool? trackChanges)
        {
            var assemblyNoteGroup = await _manager.AssemblyNoteRepository.GetAssemblyNoteByIdAsync(id, trackChanges);
            _manager.AssemblyNoteRepository.DeleteAssemblyNote(assemblyNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyNoteDto>(assemblyNoteGroup);
        }

        public async Task<IEnumerable<AssemblyNoteDto>> GetAllAssemblyNoteAsync(bool? trackChanges)
        {
            var assemblyNoteGroup = await _manager.AssemblyNoteRepository.GetAllAssemblyNoteAsync(trackChanges);
            return _mapper.Map<IEnumerable<AssemblyNoteDto>>(assemblyNoteGroup);
        }

        public async Task<IEnumerable<AssemblyNoteDto>> GetAllAssemblyNoteByManualAsync(int id, bool? trackChanges)
        {
            var assemblyNoteGroup = await _manager.AssemblyNoteRepository.GetAllAssemblyNoteByManualAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<AssemblyNoteDto>>(assemblyNoteGroup);
        }

        public async Task<AssemblyNoteDto> GetAssemblyNoteByIdAsync(int id, bool? trackChanges)
        {
            var assemblyNoteGroup = await _manager.AssemblyNoteRepository.GetAssemblyNoteByIdAsync(id, trackChanges);
            return _mapper.Map<AssemblyNoteDto>(assemblyNoteGroup);
        }

        public async Task<AssemblyNoteDto> UpdateAssemblyNoteAsync(AssemblyNoteDtoForUpdate assemblyNoteGroupDtoForUpdate)
        {
            var assemblyNoteGroup = await _manager.AssemblyNoteRepository.GetAssemblyNoteByIdAsync(assemblyNoteGroupDtoForUpdate.ID, assemblyNoteGroupDtoForUpdate.TrackChanges);
            _mapper.Map(assemblyNoteGroupDtoForUpdate, assemblyNoteGroup);
            _manager.AssemblyNoteRepository.UpdateAssemblyNote(assemblyNoteGroup);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyNoteDto>(assemblyNoteGroup);
        }
    }
}
