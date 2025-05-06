using AutoMapper;
using Entities.DTOs.AssemblyQualityDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AssemblyQualityService : IAssemblyQualityService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AssemblyQualityService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<AssemblyQualityDto> CreateAssemblyQualityAsync(AssemblyQualityDtoForInsertion assemblyQualityDtoForInsertion)
        {
            var assemblyQuality = _mapper.Map<AssemblyQuality>(assemblyQualityDtoForInsertion);
            if (assemblyQualityDtoForInsertion.UserId == null)
            {
                throw new Exception("Kalite sorumlusu giriniz!");
            }
            if (assemblyQualityDtoForInsertion.UserId == assemblyQuality.AssemblyFailureState!.AssemblyManuel!.QualityOfficerID)
            {
                _manager.AssemblyQualityRepository.CreateAssemblyQuality(assemblyQuality);
                await _manager.SaveAsync();
                return _mapper.Map<AssemblyQualityDto>(assemblyQuality);
            }
            else
            {
                throw new Exception("Yalnızca kalite sorumlusu not bırakabilir!");
            }
        }

        public async Task<AssemblyQualityDto> DeleteAssemblyQualityAsync(int id, bool? trackChanges)
        {
            var assemblyQuality = await _manager.AssemblyQualityRepository.GetAssemblyQualityByIdAsync(id, trackChanges);
            _manager.AssemblyQualityRepository.DeleteAssemblyQuality(assemblyQuality);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyQualityDto>(assemblyQuality);
        }

        public async Task<IEnumerable<AssemblyQualityDto>> GetAllAssemblyQualityAsync(bool? trackChanges)
        {
            var assemblyQuality = await _manager.AssemblyQualityRepository.GetAllAssemblyQualityAsync(trackChanges);
            return _mapper.Map<IEnumerable<AssemblyQualityDto>>(assemblyQuality);
        }

        public async Task<IEnumerable<AssemblyQualityDto>> GetAllAssemblyQualityByFailureAsync(int id, bool? trackChanges)
        {
            var assemblyQuality = await _manager.AssemblyQualityRepository.GetAllAssemblyQualityByFailureAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<AssemblyQualityDto>>(assemblyQuality);
        }

        public async Task<AssemblyQualityDto> GetAssemblyQualityByIdAsync(int id, bool? trackChanges)
        {
            var assemblyQuality = await _manager.AssemblyQualityRepository.GetAssemblyQualityByIdAsync(id, trackChanges);
            return _mapper.Map<AssemblyQualityDto>(assemblyQuality);
        }

        public async Task<AssemblyQualityDto> UpdateAssemblyQualityAsync(AssemblyQualityDtoForUpdate assemblyQualityDtoForUpdate)
        {
            var assemblyQuality = await _manager.AssemblyQualityRepository.GetAssemblyQualityByIdAsync(assemblyQualityDtoForUpdate.ID, assemblyQualityDtoForUpdate.TrackChanges);
            _mapper.Map(assemblyQualityDtoForUpdate, assemblyQuality);
            if (assemblyQualityDtoForUpdate.UserId == null)
            {
                throw new Exception("Kalite sorumlusu giriniz!");
            }
            if (assemblyQualityDtoForUpdate.UserId == assemblyQuality.AssemblyFailureState!.QualityOfficerID)
            {
                _manager.AssemblyQualityRepository.UpdateAssemblyQuality(assemblyQuality);
                await _manager.SaveAsync();
                return _mapper.Map<AssemblyQualityDto>(assemblyQuality);
            }
            else
            {
                throw new Exception("Yalnızca kalite sorumlusu not güncelleyebilir!");
            }
        }
    }
}
