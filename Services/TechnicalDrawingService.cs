using AutoMapper;
using Entities.DTOs.TechnicalDrawingDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TechnicalDrawingService : ITechnicalDrawingService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public TechnicalDrawingService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<TechnicalDrawingDto> CreateTechnicalDrawingAsync(
            TechnicalDrawingDtoForInsertion technicalDrawingDtoForInsertion
        )
        {
            try
            {
                ConvertDatesToUtc(technicalDrawingDtoForInsertion);
                var technicalDrawing = _mapper.Map<TechnicalDrawing>(technicalDrawingDtoForInsertion);
                _manager.TechnicalDrawingRepository.CreateTechnicalDrawing(technicalDrawing);
                await _manager.SaveAsync();
                return _mapper.Map<TechnicalDrawingDto>(technicalDrawing);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<TechnicalDrawingDto> DeleteTechnicalDrawingAsync(int id, bool? trackChanges)
        {
            var technicalDrawing = await _manager.TechnicalDrawingRepository.GetTechnicalDrawingByIdAsync(id, trackChanges);
            _manager.TechnicalDrawingRepository.DeleteTechnicalDrawing(technicalDrawing);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingDto>(technicalDrawing);
        }

        public async Task<IEnumerable<TechnicalDrawingDto>> GetAllTechnicalDrawingAsync(bool? trackChanges)
        {
            var technicalDrawing = await _manager.TechnicalDrawingRepository.GetAllTechnicalDrawingAsync(trackChanges);
            return _mapper.Map<IEnumerable<TechnicalDrawingDto>>(technicalDrawing);
        }

        public async Task<TechnicalDrawingDto> GetTechnicalDrawingByIdAsync(int id, bool? trackChanges)
        {
            var technicalDrawing = await _manager.TechnicalDrawingRepository.GetTechnicalDrawingByIdAsync(id, trackChanges);
            return _mapper.Map<TechnicalDrawingDto>(technicalDrawing);
        }

        public async Task<TechnicalDrawingDto> AddFileTechnicalDrawingAsync(TechnicalDrawingDtoForAddFile technicalDrawingDtoForAddFile)
        {
            try
            {
                var technicalDrawing = await _manager.TechnicalDrawingRepository.GetTechnicalDrawingByIdAsync(technicalDrawingDtoForAddFile.ID, technicalDrawingDtoForAddFile.TrackChanges);
                var existingFiles = technicalDrawing.Files?.ToList() ?? new List<string>();
                var newFiles = technicalDrawingDtoForAddFile.Files;
                technicalDrawingDtoForAddFile.Files = null;
                _mapper.Map(technicalDrawingDtoForAddFile, technicalDrawing);
                if (newFiles != null && newFiles.Any())
                {
                    foreach (var file in newFiles)
                    {
                        existingFiles.Add(file);
                    }
                }
                technicalDrawing.Files = existingFiles;
                technicalDrawing.ProjectName = technicalDrawing.ProjectName;
                technicalDrawing.PartCode = technicalDrawing.PartCode;
                technicalDrawing.Responible = technicalDrawing.Responible;
                technicalDrawing.PersonInCharge = technicalDrawing.PersonInCharge;
                technicalDrawing.SerialNumber = technicalDrawing.SerialNumber;
                technicalDrawing.ProductionQuantity = technicalDrawing.ProductionQuantity;
                technicalDrawing.Time = technicalDrawing.Time;
                technicalDrawing.Date = technicalDrawing.Date;
                technicalDrawing.Description = technicalDrawing.Description;
                technicalDrawing.OperatorDate = technicalDrawing.OperatorDate;
                technicalDrawing.UserId = technicalDrawingDtoForAddFile.UserId;

                _manager.TechnicalDrawingRepository.AddFileTechnicalDrawing(technicalDrawing);
                await _manager.SaveAsync();
                return _mapper.Map<TechnicalDrawingDto>(technicalDrawing);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<TechnicalDrawingDto> UpdateTechnicalDrawingAsync(TechnicalDrawingDtoForUpdate technicalDrawingDtoForUpdate)
        {
            var technicalDrawing = await _manager.TechnicalDrawingRepository.GetTechnicalDrawingByIdAsync(technicalDrawingDtoForUpdate.ID, technicalDrawingDtoForUpdate.TrackChanges);
            ConvertDatesToUtc(technicalDrawingDtoForUpdate);
            var existingFiles = technicalDrawing.Files?.ToList() ?? new List<string>();
            var newFiles = technicalDrawingDtoForUpdate.Files;
            technicalDrawingDtoForUpdate.Files = null;
            _mapper.Map(technicalDrawingDtoForUpdate, technicalDrawing);
            if (newFiles != null && newFiles.Any())
            {
                foreach (var file in newFiles)
                {
                    existingFiles.Add(file);
                }
            }
            technicalDrawing.Files = existingFiles;
            _manager.TechnicalDrawingRepository.UpdateTechnicalDrawing(technicalDrawing);
            await _manager.SaveAsync();
            return _mapper.Map<TechnicalDrawingDto>(technicalDrawing);
        }

        private void ConvertDatesToUtc<T>(T dto) where T : TechnicalDrawingDtoForManipulation
        {
            if (dto.Date.HasValue)
                dto.Date = DateTime.SpecifyKind(dto.Date.Value, DateTimeKind.Utc);

            if (dto.OperatorDate.HasValue)
                dto.OperatorDate = DateTime.SpecifyKind(dto.OperatorDate.Value, DateTimeKind.Utc);
        }
    }
}
