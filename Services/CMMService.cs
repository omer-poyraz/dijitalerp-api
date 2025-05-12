using AutoMapper;
using Entities.DTOs.CMMDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CMMService : ICMMService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CMMService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CMMDto> CreateCMMAsync(CMMDtoForInsertion cmmDtoForInsertion)
        {
            try
            {
                ConvertDatesToUtc(cmmDtoForInsertion);
                var cmm = _mapper.Map<CMM>(cmmDtoForInsertion);
                _manager.CMMRepository.CreateCMM(cmm);
                await _manager.SaveAsync();
                return _mapper.Map<CMMDto>(cmm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<CMMDto> DeleteCMMAsync(int id, bool? trackChanges)
        {
            var cmm = await _manager.CMMRepository.GetCMMByIdAsync(id, trackChanges);
            _manager.CMMRepository.DeleteCMM(cmm);
            await _manager.SaveAsync();
            return _mapper.Map<CMMDto>(cmm);
        }

        public async Task<IEnumerable<CMMDto>> GetAllCMMAsync(bool? trackChanges)
        {
            try
            {
                var cmm = await _manager.CMMRepository.GetAllCMMAsync(trackChanges);
                return _mapper.Map<IEnumerable<CMMDto>>(cmm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<CMMDto> GetCMMByIdAsync(int id, bool? trackChanges)
        {
            var cmm = await _manager.CMMRepository.GetCMMByIdAsync(id, trackChanges);
            return _mapper.Map<CMMDto>(cmm);
        }

        public async Task<CMMDto> AddFileCMMAsync(CMMDtoForAddFile cmmDtoForAddFile)
        {
            var cmm = await _manager.CMMRepository.GetCMMByIdAsync(cmmDtoForAddFile.ID, cmmDtoForAddFile.TrackChanges);
            var existingFiles = cmm.Files?.ToList() ?? new List<string>();
            var newFiles = cmmDtoForAddFile.Files;
            cmmDtoForAddFile.Files = null;
            _mapper.Map(cmmDtoForAddFile, cmm);
            if (newFiles != null && newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    existingFiles.Add(file);
                }
            }

            _manager.CMMRepository.AddFileCMM(cmm);
            await _manager.SaveAsync();
            return _mapper.Map<CMMDto>(cmm);
        }

        public async Task<CMMDto> AddResultFileCMMAsync(CMMDtoForAddResultFile cmmDtoForAddResultFile)
        {
            var cmm = await _manager.CMMRepository.GetCMMByIdAsync(cmmDtoForAddResultFile.ID, cmmDtoForAddResultFile.TrackChanges);
            var existingFiles = cmm.Files?.ToList() ?? new List<string>();
            var newFiles = cmmDtoForAddResultFile.ResultFiles;
            cmmDtoForAddResultFile.ResultFiles = null;
            _mapper.Map(cmmDtoForAddResultFile, cmm);
            if (newFiles != null && newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    existingFiles.Add(file);
                }
            }

            _manager.CMMRepository.AddResultFileCMM(cmm);
            await _manager.SaveAsync();
            return _mapper.Map<CMMDto>(cmm);
        }

        public async Task<CMMDto> UpdateCMMAsync(CMMDtoForUpdate cmmDtoForUpdate)
        {
            var cmm = await _manager.CMMRepository.GetCMMByIdAsync(cmmDtoForUpdate.ID, cmmDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(cmmDtoForUpdate);

            var existingFiles = cmm.Files?.ToList() ?? new List<string>();
            var newFiles = cmmDtoForUpdate.Files?.ToList() ?? new List<string>();

            cmmDtoForUpdate.Files = null;
            _mapper.Map(cmmDtoForUpdate, cmm);

            if (newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    if (!existingFiles.Contains(file))
                        existingFiles.Add(file);
                }
            }
            cmm.Files = existingFiles;

            _manager.CMMRepository.UpdateCMM(cmm);
            await _manager.SaveAsync();
            return _mapper.Map<CMMDto>(cmm);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : CMMDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);

            if (dto.InstallResultDate.HasValue)
                dto.InstallResultDate = DateTime.SpecifyKind(dto.InstallResultDate.Value, DateTimeKind.Utc);
        }
    }
}
