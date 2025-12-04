using HRIS.Domain.Enums;
using MediatR;

namespace HRIS.Application.Employees.Commands.CreateEmployee
{
    // Returns the new EmployeeId (Guid) after creating
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string EmploymentID { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public ExtensionName? ExtensionName { get; set; }       // using enum
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public char SexAtBirth { get; set; }
        public int CivilStatusID { get; set; }
        public bool IsFilipino { get; set; }
        public bool IsDualCitizen { get; set; }
        public string? ImageSource { get; set; }
    }
}
