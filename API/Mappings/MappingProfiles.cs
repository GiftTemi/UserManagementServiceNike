using AutoMapper;
using Domain.DTOs;
using Domain.DTOs.User;
using Domain.Entities;

namespace API.Mappings
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserDTO,User>().ReverseMap();
            CreateMap<CreateEmployeeDTO, Employee>().ReverseMap();

        }

        internal class Assembly
        {
        }
    }
}
