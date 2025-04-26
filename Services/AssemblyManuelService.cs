using AutoMapper;
using Entities.DTOs.AssemblyManuelDto;
using Entities.Models;
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
            try
            {
                ConvertDatesToUtc(assemblyManuelDtoForInsertion);
                var assemblyManuel = _mapper.Map<AssemblyManuel>(assemblyManuelDtoForInsertion);
                _manager.AssemblyManuelRepository.CreateAssemblyManuel(assemblyManuel);
                await _manager.SaveAsync();
                return _mapper.Map<AssemblyManuelDto>(assemblyManuel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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

        public async Task<AssemblyManuelDto> AddFileAssemblyManuelAsync(AssemblyManuelDtoForAddFile assemblyManuelDtoForAddFile)
        {
            var assemblyManuel = await _manager.AssemblyManuelRepository.GetAssemblyManuelByIdAsync(assemblyManuelDtoForAddFile.ID, assemblyManuelDtoForAddFile.TrackChanges);
            var existingFiles = assemblyManuel.Files?.ToList() ?? new List<string>();
            var newFiles = assemblyManuelDtoForAddFile.Files;
            assemblyManuelDtoForAddFile.Files = null;
            _mapper.Map(assemblyManuelDtoForAddFile, assemblyManuel);
            if (newFiles != null && newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    existingFiles.Add(file);
                }
            }
            assemblyManuel.Files = existingFiles;
            assemblyManuel.ProjectName = assemblyManuel.ProjectName;
            assemblyManuel.PartCode = assemblyManuel.PartCode;
            assemblyManuel.Responible = assemblyManuel.Responible;
            assemblyManuel.PersonInCharge = assemblyManuel.PersonInCharge;
            assemblyManuel.SerialNumber = assemblyManuel.SerialNumber;
            assemblyManuel.ProductionQuantity = assemblyManuel.ProductionQuantity;
            assemblyManuel.Time = assemblyManuel.Time;
            assemblyManuel.Date = assemblyManuel.Date;
            assemblyManuel.Description = assemblyManuel.Description;
            assemblyManuel.TechnicianDate = assemblyManuel.TechnicianDate;
            assemblyManuel.UserId = assemblyManuelDtoForAddFile.UserId;

            _manager.AssemblyManuelRepository.AddFileAssemblyManuel(assemblyManuel);
            await _manager.SaveAsync();
            return _mapper.Map<AssemblyManuelDto>(assemblyManuel);
        }

        public async Task<AssemblyManuelDto> UpdateAssemblyManuelAsync(AssemblyManuelDtoForUpdate assemblyManuelDtoForUpdate)
        {
            var assemblyManuel = await _manager.AssemblyManuelRepository.GetAssemblyManuelByIdAsync(assemblyManuelDtoForUpdate.ID, assemblyManuelDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(assemblyManuelDtoForUpdate);
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

        private void ConvertDatesToUtc<T>(T dto) where T : AssemblyManuelDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);

            if (dto.TechnicianDate.HasValue)
                dto.TechnicianDate = DateTime.SpecifyKind(dto.TechnicianDate.Value, DateTimeKind.Utc);
        }
    }
}
