using AutoMapper;
using UniversitySystem.Application.Features.Students.Commands.CreateStudent;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Students.Commands
{
    public class CommandMappingProfile : Profile
    {
        public CommandMappingProfile()
        {
            CreateMap<CreateStudentCommand, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
