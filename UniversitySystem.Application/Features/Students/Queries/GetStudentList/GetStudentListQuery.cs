using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Application.Features.Students.Queries.Models;
using UniversitySystem.Application.Interfaces;

namespace UniversitySystem.Application.Features.Students.Queries.GetStudentList
{
    public record GetStudentListQuery : IRequest<List<StudentItemDto>>;

    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentItemDto>>
    {
        private readonly IAppDbContext _context;

        public GetStudentListHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentItemDto>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {

            return await _context.Students
                .AsNoTracking()
                .Select(s => new StudentItemDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PersonalEmail = s.PersonalEmail,
                    Level = s.Level,
                    DepartmentId = s.DepartmentId,
                })
                .ToListAsync(cancellationToken);
        }
    }

}
