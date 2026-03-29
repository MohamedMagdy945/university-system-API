using FluentValidation;

namespace UniversitySystem.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.PersonalEmail)
                .NotEmpty().WithMessage("Personal email is required.")
                .Matches(emailRegex).WithMessage("Invalid email format.");

            RuleFor(x => x.Level)
                .InclusiveBetween(1, 10).WithMessage("Level must be between 1 and 10.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");
        }
    }
}
