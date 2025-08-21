using Azure.Core;
using CafeApp.Application.Commands.AddEmployee;
using CafeApp.Application.Commands.DeleteEmployee;
using CafeApp.Application.Commands.UpdateCafe;
using CafeApp.Application.Commands.UpdateEmployee;
using CafeApp.Application.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("employee")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] AddEmployeeDto employeedto)
        {
            // This method should add a new employee
            // Implementation goes here
            if (employeedto == null)
            {
                return BadRequest("Employee data is required.");
            }

            if (string.IsNullOrWhiteSpace(employeedto.Name) || string.IsNullOrWhiteSpace(employeedto.EmailAddress))
            {
                return BadRequest("Employee name and email address are required.");
            }
            if (employeedto.PhoneNumber.Length != 8 || !employeedto.PhoneNumber.StartsWith("8") && !employeedto.PhoneNumber.StartsWith("9"))
            {
                return BadRequest("Phone number must be 8 digits and start with 8 or 9.");
            }
            var result = await _mediator.Send(new AddEmployeeCommand(employeedto));

            return Ok(result);
        }
        [HttpPut("employee")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] UpdateEmployeeDto employeedto)
        {
            // This method should update an existing employee
            // Implementation goes here
            if (employeedto == null)
            {
                return BadRequest("Employee data is required.");
            }

            if (string.IsNullOrWhiteSpace(employeedto.name) || string.IsNullOrWhiteSpace(employeedto.email_address))
            {
                return BadRequest("Employee name and email address are required.");
            }
            if (employeedto.phone_number.Length != 8 || !employeedto.phone_number.StartsWith("8") && !employeedto.phone_number.StartsWith("9"))
            {
                return BadRequest("Phone number must be 8 digits and start with 8 or 9.");
            }
            var result = await _mediator.Send(new UpdateEmployeeCommand(employeedto));
            return Ok(employeedto);
        }
        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployeesAsync([FromQuery]Guid? cafeid=null)
        {
            // This method should return a list of employees based on the cafe
            // Implementation goes here
            
                var employees = await _mediator.Send(new GetEmployeesQuery(cafeid));
                return Ok(employees);
            
            
          
        }
        [HttpDelete("employee")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromQuery]string id)
        {
            // This method should delete an employee by ID
            // Implementation goes here
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Employee ID is required.");
            }
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            if (result)
            {
                return Ok("Employee deleted successfully.");
            }
            return NotFound("Employee not found.");
        }
       
    }
}
