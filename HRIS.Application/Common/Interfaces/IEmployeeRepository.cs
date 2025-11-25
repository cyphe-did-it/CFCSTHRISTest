using HRIS.Domain.Entities.Domain.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(Guid employeeId, CancellationToken cancellationToken );
        Task<bool> EmploymentIdExistsAsync(string employmentId, CancellationToken cancellationToken );
        Task AddAsync(Employee employee, CancellationToken cancellationToken);
    }
}
