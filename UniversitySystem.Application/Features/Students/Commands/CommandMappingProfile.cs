using AutoMapper;
using UniversitySystem.Application.Features.Students.Commands.CreateStudent;
using UniversitySystem.Application.Features.Students.Commands.UpdateStudent;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Students.Commands
{
    public class CommandMappingProfile : Profile
    {
        public CommandMappingProfile()
        {
            CreateMap<CreateStudentCommand, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateStudentCommand, Student>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForAllMembers(opt =>
               {
                   opt.Condition((src, dest, srcMember) => srcMember != null);
               });
        }
    }
}
