using AutoMapper;
using MediatR;
using UniversitySystem.Application.Bases;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Students.Commands.CreateStudent
{
    public record CreateStudentCommand(string Name, string PersonalEmail, int Level, int DepartmentId) : IRequest<Response<int>>;
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Response<int>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateStudentHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request);


            var result = await _context.Students.AddAsync(studentEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseHandler.Success<int>(studentEntity.Id);

        }
    }
}
