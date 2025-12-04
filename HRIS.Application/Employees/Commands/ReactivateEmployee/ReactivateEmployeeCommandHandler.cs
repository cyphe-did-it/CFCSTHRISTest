using HRIS.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands.ReactivateEmployee
{
    public class ReactivateEmployeeCommandHandler : IRequestHandler<ReactivateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ReactivateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(
            ReactivateEmployeeCommand request, 
            CancellationToken cancellationToken
        )
        {
            var employee = await _employeeRepository.GetInactiveEmployeeByIDAsync(request.EmployeeID, cancellationToken);
            if (employee == null)
            {
                return false; 
            }
            employee.Reactivate("system", request.ReactivationReason);
            employee.MarkUpdated("system");

            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            
            return true; 
        }
    }
}
