using AutoMapper;
using Entities.DTOs.ServicesDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServicesService : IServicesService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ServicesService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ServicesDto> CreateServicesAsync(
            ServicesDtoForInsertion servicesGroupDtoForInsertion
        )
        {
            var servicesGroup = _mapper.Map<Entities.Models.Services>(servicesGroupDtoForInsertion);
            _manager.ServicesRepository.CreateServices(servicesGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ServicesDto>(servicesGroup);
        }

        public async Task<ServicesDto> DeleteServicesAsync(int id, bool? trackChanges)
        {
            var servicesGroup = await _manager.ServicesRepository.GetServicesByIdAsync(id, trackChanges);
            _manager.ServicesRepository.DeleteServices(servicesGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ServicesDto>(servicesGroup);
        }

        public async Task<IEnumerable<ServicesDto>> GetAllServicesAsync(bool? trackChanges)
        {
            var servicesGroup = await _manager.ServicesRepository.GetAllServicesAsync(trackChanges);
            return _mapper.Map<IEnumerable<ServicesDto>>(servicesGroup);
        }

        public async Task<ServicesDto> GetServicesByIdAsync(int id, bool? trackChanges)
        {
            var servicesGroup = await _manager.ServicesRepository.GetServicesByIdAsync(id, trackChanges);
            return _mapper.Map<ServicesDto>(servicesGroup);
        }

        public async Task<ServicesDto> UpdateServicesAsync(ServicesDtoForUpdate servicesGroupDtoForUpdate)
        {
            var servicesGroup = await _manager.ServicesRepository.GetServicesByIdAsync(servicesGroupDtoForUpdate.ID, servicesGroupDtoForUpdate.TrackChanges);
            _mapper.Map(servicesGroupDtoForUpdate, servicesGroup);
            _manager.ServicesRepository.UpdateServices(servicesGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ServicesDto>(servicesGroup);
        }
    }
}
