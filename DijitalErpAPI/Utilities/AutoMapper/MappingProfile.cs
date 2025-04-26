using AutoMapper;
using Entities.DTOs.AssemblyFailureStateDto;
using Entities.DTOs.AssemblyManuelDto;
using Entities.DTOs.AssemblyNoteDto;
using Entities.DTOs.AssemblySuccessStateDto;
using Entities.DTOs.DepartmentDto;
using Entities.DTOs.EmployeeDto;
using Entities.DTOs.LogDto;
using Entities.DTOs.ProductDto;
using Entities.DTOs.ServicesDto;
using Entities.DTOs.TechnicalDrawingDto;
using Entities.DTOs.TechnicalDrawingFailureStateDto;
using Entities.DTOs.TechnicalDrawingNoteDto;
using Entities.DTOs.TechnicalDrawingSuccessStateDto;
using Entities.DTOs.UserDto;
using Entities.DTOs.UserPermissionDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace DijitalErpAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssemblyFailureStateDtoForUpdate, AssemblyFailureState>().ReverseMap();
            CreateMap<AssemblyFailureState, AssemblyFailureStateDto>();
            CreateMap<AssemblyFailureStateDtoForInsertion, AssemblyFailureState>();

            CreateMap<AssemblyManuelDtoForAddFile, AssemblyManuel>().ReverseMap();
            CreateMap<AssemblyManuelDtoForUpdate, AssemblyManuel>().ReverseMap();
            CreateMap<AssemblyManuel, AssemblyManuelDto>();
            CreateMap<AssemblyManuelDtoForInsertion, AssemblyManuel>();

            CreateMap<AssemblyNoteDtoForUpdate, AssemblyNote>().ReverseMap();
            CreateMap<AssemblyNote, AssemblyNoteDto>();
            CreateMap<AssemblyNoteDtoForInsertion, AssemblyNote>();

            CreateMap<AssemblySuccessStateDtoForUpdate, AssemblySuccessState>().ReverseMap();
            CreateMap<AssemblySuccessState, AssemblySuccessStateDto>();
            CreateMap<AssemblySuccessStateDtoForInsertion, AssemblySuccessState>();

            CreateMap<DepartmentDtoForUpdate, Department>().ReverseMap();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDtoForInsertion, Department>();

            CreateMap<EmployeeDtoForUpdate, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDtoForInsertion, Employee>();

            CreateMap<LogDtoForInsertion, Log>();
            CreateMap<Log, LogDto>();

            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForInsertion, Product>();

            CreateMap<ServicesDtoForUpdate, Entities.Models.Services>().ReverseMap();
            CreateMap<Entities.Models.Services, ServicesDto>();
            CreateMap<ServicesDtoForInsertion, Entities.Models.Services>();

            CreateMap<TechnicalDrawingDtoForUpdate, TechnicalDrawing>().ReverseMap();
            CreateMap<TechnicalDrawing, TechnicalDrawingDto>();
            CreateMap<TechnicalDrawingDtoForInsertion, TechnicalDrawing>();

            CreateMap<TechnicalDrawingFailureStateDtoForUpdate, TechnicalDrawingFailureState>().ReverseMap();
            CreateMap<TechnicalDrawingFailureState, TechnicalDrawingFailureStateDto>();
            CreateMap<TechnicalDrawingFailureStateDtoForInsertion, TechnicalDrawingFailureState>();

            CreateMap<TechnicalDrawingSuccessStateDtoForUpdate, TechnicalDrawingSuccessState>().ReverseMap();
            CreateMap<TechnicalDrawingSuccessState, TechnicalDrawingSuccessStateDto>();
            CreateMap<TechnicalDrawingSuccessStateDtoForInsertion, TechnicalDrawingSuccessState>();

            CreateMap<TechnicalDrawingNoteDtoForUpdate, TechnicalDrawingNote>().ReverseMap();
            CreateMap<TechnicalDrawingNote, TechnicalDrawingNoteDto>();
            CreateMap<TechnicalDrawingNoteDtoForInsertion, TechnicalDrawingNote>();

            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserDtoForUpdate, User>().ReverseMap();
            CreateMap<User, UserDto>();
            CreateMap<IdentityResult, UserDto>().ReverseMap();

            CreateMap<UserPermissionDtoForUpdate, UserPermission>().ReverseMap();
            CreateMap<UserPermission, UserPermissionDto>();
            CreateMap<UserPermissionDtoForInsertion, UserPermission>();
        }
    }
}
