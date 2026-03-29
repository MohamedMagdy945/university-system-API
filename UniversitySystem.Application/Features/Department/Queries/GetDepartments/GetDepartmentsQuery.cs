using MediatR;

namespace UniversitySystem.Application.Features.Department.Queries.GetDepartments
{
    public class GetDepartmentsQuery : IRequest<List<DepartmentSummaryResponse>>
    {

    }
}
