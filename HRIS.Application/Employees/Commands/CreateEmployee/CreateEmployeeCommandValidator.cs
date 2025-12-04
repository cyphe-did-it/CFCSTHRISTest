using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.EmploymentID)
                .NotEmpty().WithMessage("Employment ID is required.")
                .Matches(@"^CFCST-\d{4}-d{4}$:")
                    .WithMessage("Employment ID must follow the format CFCST-YYYY-NNNN.")
                .Must(id =>
                {
                    // extra sanity checks
                    var parts = id.Split('-');
                    if (parts.Length != 3) return false;

                    // year must be numeric and reasonable:
                    if (!int.TryParse(parts[1], out int year)) return false;
                    if (year < 1900 || year > DateTime.UtcNow.Year + 1) return false;

                    // if sequence must be > 0 (0000 is not allowed)
                    if (!int.TryParse(parts[2], out int seq)) return false;
                    if (seq <= 0) return false;

                    return true;
                })
                    .WithMessage("Employment ID contains invalid year or sequence number.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(100).WithMessage("First Name cannot exceed 100 characters.");


            RuleFor(x => x.MiddleName)
                .MaximumLength(100).WithMessage("Middle Name cannot exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(100).WithMessage("Last Name cannot exceed 100 characters.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth Date is required.")
                .LessThan(DateTime.UtcNow).WithMessage("Birth Date must be in the past.");

            RuleFor(x => x.BirthPlace)
                .NotEmpty().WithMessage("Birth Place is required.")
                .MaximumLength(150).WithMessage("Birth Place cannot exceed 150 characters.");

            RuleFor(x => x.SexAtBirth)
                .NotEmpty().WithMessage("Sex at Birth is required.")
                .Must(c => c == 'M' || c == 'F').WithMessage("Sex at Birth must be 'M' or 'F' only.");

            RuleFor(x => x.CivilStatusID)
                .NotEmpty().WithMessage("Civil Status is required.")
                .GreaterThan(0).WithMessage("Civil Status ID must be a valid positive integer.");

            RuleFor(x => x.IsFilipino)
                .NotNull().WithMessage("IsFilipino must be specified.");

            RuleFor(x => x.IsDualCitizen)
                .NotNull().WithMessage("IsDualCitizen must be specified.");

            RuleFor(x => x.ImageSource)
                .MaximumLength(255).WithMessage("Image Source cannot exceed 255 characters.");

        }
    }
}
