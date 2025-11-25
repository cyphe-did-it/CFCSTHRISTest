using HRIS.Application.Features.Employees.Commands.CreateEmployee;
using HRIS.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS.WebAPI.Controllers.HRIS
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id = id }, null);
        }

        // POST: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] HRISDbContext dbContext)
        {
            var employees = await dbContext.Employees.ToListAsync();
            return Ok(employees);

        }

        // POST: api/Employees/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromServices] HRISDbContext dbContext, int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
