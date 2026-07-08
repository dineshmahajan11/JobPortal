using AutoMapper;
using JobPortal.DTOs;
using JobPortal.Models;

namespace JobPortal.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> DTO
            CreateMap<User, UserDto>();

            CreateMap<Job, JobDto>();

            // DTO -> Entity
            CreateMap<RegisterDto, User>();

            CreateMap<CreateJobDto, Job>();
        }
    }
}