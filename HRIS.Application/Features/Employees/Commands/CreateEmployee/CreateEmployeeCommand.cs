using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string EmploymentID { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MidlleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? ExtensionName { get; set; }

        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; } = null!;
        public string SexAtBirth { get; set; } = null!;

        public int CivilStatusID { get; set; }      // FK
        public bool IsFilipino { get; set; }
        public bool IsDualCitizen { get; set; }
        public string ImageSource { get; set; } = string.Empty;
    }
}
