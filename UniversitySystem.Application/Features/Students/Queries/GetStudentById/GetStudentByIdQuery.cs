using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Application.Bases;
using UniversitySystem.Application.Features.Students.Queries.Models;
using UniversitySystem.Application.Interfaces;

namespace UniversitySystem.Application.Features.Students.Queries.GetStudentById
{
    public record GetStudentByIdQuery(int Id) : IRequest<Response<StudentItemDto>>;

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Response<StudentItemDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetStudentByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<StudentItemDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {

            var studentDto = await _context.Students
                .Where(s => s.Id == request.Id)
                .ProjectTo<StudentItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (studentDto is null)
            {
                List<string> errors = new() { $"No student found with ID {request.Id}" };
                return ResponseHandler.NotFound<StudentItemDto>(errors: errors);

            }
            return ResponseHandler.Success(studentDto);


        }
    }
}
