using HRIS.Application.Common.Interfaces;
using HRIS.Domain.Entities.Domain.HRIS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Business rule validation for unique EmploymentID
            var existingEmployee = await _employeeRepository.EmploymentIdExistsAsync(request.EmploymentID, cancellationToken);

            if (existingEmployee)
            {
                throw new InvalidOperationException($"An employee with EmploymentID '{request.EmploymentID}' already exists."); // Custom exception can be created for better error handling
            }

            var employee = new Employee
            {
                EmploymentID = request.EmploymentID,
                FirstName = request.FirstName,
                MiddleName = request.MidlleName,
                LastName = request.LastName,
                ExtensionName = request.ExtensionName, 
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                SexAtBirth = request.SexAtBirth,
                CivilStatusID = request.CivilStatusID,
                IsFilipino = request.IsFilipino,
                IsDualCitizen = request.IsDualCitizen,
                ImageSource = request.ImageSource
            };

            await _employeeRepository.AddAsync(employee, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            return employee.EmployeeID;
        }
    }
}
