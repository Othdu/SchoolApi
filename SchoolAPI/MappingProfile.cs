using AutoMapper;
using SchoolAPI.DTOs;
using SchoolAPI.models;

namespace SchoolAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Student, StudentResponseDto>();
            CreateMap<StudentDto, Student>();
        
        
        }
    }
}