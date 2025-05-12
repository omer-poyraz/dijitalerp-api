using AutoMapper;
using Entities.DTOs.CMMModuleDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CMMModuleService : ICMMModuleService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CMMModuleService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CMMModuleDto> CreateCMMModuleAsync(
            CMMModuleDtoForInsertion cmmModuleDtoForInsertion
        )
        {
            try
            {
                var cmmModule = _mapper.Map<CMMModule>(cmmModuleDtoForInsertion);
                _manager.CMMModuleRepository.CreateCMMModule(cmmModule);
                await _manager.SaveAsync();
                return _mapper.Map<CMMModuleDto>(cmmModule);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<CMMModuleDto> DeleteCMMModuleAsync(int id, bool? trackChanges)
        {
            var cmmModule = await _manager.CMMModuleRepository.GetCMMModuleByIdAsync(id, trackChanges);
            _manager.CMMModuleRepository.DeleteCMMModule(cmmModule);
            await _manager.SaveAsync();
            return _mapper.Map<CMMModuleDto>(cmmModule);
        }

        public async Task<IEnumerable<CMMModuleDto>> GetAllCMMModuleAsync(bool? trackChanges)
        {
            var cmmModule = await _manager.CMMModuleRepository.GetAllCMMModuleAsync(trackChanges);
            return _mapper.Map<IEnumerable<CMMModuleDto>>(cmmModule);
        }

        public async Task<CMMModuleDto> GetCMMModuleByIdAsync(int id, bool? trackChanges)
        {
            var cmmModule = await _manager.CMMModuleRepository.GetCMMModuleByIdAsync(id, trackChanges);
            return _mapper.Map<CMMModuleDto>(cmmModule);
        }

        public async Task<CMMModuleDto> AddFileCMMModuleAsync(CMMModuleDtoForAddFile cmmModuleDtoForAddFile)
        {
            var cmmModule = await _manager.CMMModuleRepository.GetCMMModuleByIdAsync(cmmModuleDtoForAddFile.ID, cmmModuleDtoForAddFile.TrackChanges);
            var existingFiles = cmmModule.Files?.ToList() ?? new List<string>();
            var newFiles = cmmModuleDtoForAddFile.Files;
            cmmModuleDtoForAddFile.Files = null;
            _mapper.Map(cmmModuleDtoForAddFile, cmmModule);
            if (newFiles != null && newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    existingFiles.Add(file);
                }
            }

            _manager.CMMModuleRepository.AddFileCMMModule(cmmModule);
            await _manager.SaveAsync();
            return _mapper.Map<CMMModuleDto>(cmmModule);
        }

        public async Task<CMMModuleDto> UpdateCMMModuleAsync(CMMModuleDtoForUpdate cmmModuleDtoForUpdate)
        {
            var cmmModule = await _manager.CMMModuleRepository.GetCMMModuleByIdAsync(cmmModuleDtoForUpdate.ID, cmmModuleDtoForUpdate.TrackChanges);

            var existingFiles = cmmModule.Files?.ToList() ?? new List<string>();
            var newFiles = cmmModuleDtoForUpdate.Files?.ToList() ?? new List<string>();

            cmmModuleDtoForUpdate.Files = null;
            _mapper.Map(cmmModuleDtoForUpdate, cmmModule);

            foreach (var file in newFiles)
            {
                if (!existingFiles.Contains(file))
                    existingFiles.Add(file);
            }

            cmmModule.Files = existingFiles;
            _manager.CMMModuleRepository.UpdateCMMModule(cmmModule);
            await _manager.SaveAsync();
            return _mapper.Map<CMMModuleDto>(cmmModule);
        }
    }
}
