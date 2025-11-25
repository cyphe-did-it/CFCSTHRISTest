using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities.Domain.HRIS;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Repositories.HRIS
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRISDbContext _context;

        public EmployeeRepository(HRISDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Employees.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IReadOnlyList<Employee>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Employees.ToListAsync(cancellationToken);
        }

        public async Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken); 
            await _context.SaveChangesAsync(cancellationToken);

            return employee;
        }

        public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
