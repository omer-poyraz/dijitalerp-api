using AutoMapper;
using Entities.DTOs.AssemblyManuelDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AssemblyManuelService : IAssemblyManuelService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AssemblyManuelService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<AssemblyManuelDto> CreateAssemblyManuelAsync(
            AssemblyManuelDtoForInsertion assemblyManuelDtoForInsertion
        )
        {
            var assemblyManuel = _mapper.Map<Entities.Models.AssemblyManuel>(assemblyManuelDtoForInsertion);
            _manager.AssemblyManuelRepository.CreateAssemblyManuel(assemblyManuel);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyManuelDto>(assemblyManuel);
        }

        public async Task<AssemblyManuelDto> DeleteAssemblyManuelAsync(int id, bool? trackChanges)
        {
            var assemblyManuel = await _manager.AssemblyManuelRepository.GetAssemblyManuelByIdAsync(id, trackChanges);
            _manager.AssemblyManuelRepository.DeleteAssemblyManuel(assemblyManuel);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyManuelDto>(assemblyManuel);
        }

        public async Task<IEnumerable<AssemblyManuelDto>> GetAllAssemblyManuelAsync(bool? trackChanges)
        {
            var assemblyManuel = await _manager.AssemblyManuelRepository.GetAllAssemblyManuelAsync(trackChanges);
            return _mapper.Map<IEnumerable<AssemblyManuelDto>>(assemblyManuel);
        }

        public async Task<AssemblyManuelDto> GetAssemblyManuelByIdAsync(int id, bool? trackChanges)
        {
            var assemblyManuel = await _manager.AssemblyManuelRepository.GetAssemblyManuelByIdAsync(id, trackChanges);
            return _mapper.Map<AssemblyManuelDto>(assemblyManuel);
        }

        public async Task<AssemblyManuelDto> UpdateAssemblyManuelAsync(AssemblyManuelDtoForUpdate assemblyManuelDtoForUpdate)
        {
            var assemblyManuel = await _manager.AssemblyManuelRepository.GetAssemblyManuelByIdAsync(assemblyManuelDtoForUpdate.ID, assemblyManuelDtoForUpdate.TrackChanges);
            var existingFiles = assemblyManuel.Files?.ToList() ?? new List<string>();
            var newFiles = assemblyManuelDtoForUpdate.Files;
            assemblyManuelDtoForUpdate.Files = null;
            _mapper.Map(assemblyManuelDtoForUpdate, assemblyManuel);
            if (newFiles != null && newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    existingFiles.Add(file);
                }
            }
            assemblyManuel.Files = existingFiles;
            _manager.AssemblyManuelRepository.UpdateAssemblyManuel(assemblyManuel);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyManuelDto>(assemblyManuel);
        }
    }
}
