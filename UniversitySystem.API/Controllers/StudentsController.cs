using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.Features.Students.Queries.GetStudentList;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var students = await _mediator.Send(new GetStudentListQuery(), cancellationToken);
            return Ok(students);
        }
    }
}
