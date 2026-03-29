using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.Features.Students.Commands.CreateStudent;
using UniversitySystem.Application.Features.Students.Queries.GetStudentById;
using UniversitySystem.Application.Features.Students.Queries.GetStudentList;

namespace UniversitySystem.API.Controllers
{
    public class StudentsController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStudents(CancellationToken cancellationToken)
        {
            var students = await _mediator.Send(new GetStudentListQuery(), cancellationToken);
            return NewResult(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id, CancellationToken cancellationToken)
        {
            var students = await _mediator.Send(new GetStudentByIdQuery(id), cancellationToken);
            return NewResult(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return NewResult(result);
        }
    }

}