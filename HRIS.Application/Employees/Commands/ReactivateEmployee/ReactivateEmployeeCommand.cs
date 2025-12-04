using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands.ReactivateEmployee
{
    public class ReactivateEmployeeCommand : IRequest<bool>
    {
        public Guid EmployeeID { get; set; }
        public string? ReactivationReason { get; set; }
    }
}
