using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository):IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        public Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.EmployeeDto != null)
            {
                var existingEmployee = employeeRepository.GetEmployeeByIdAsync(request.EmployeeDto.id).Result;
                if (existingEmployee == null) return null;
                existingEmployee.id = request.EmployeeDto.id;
                existingEmployee.name = request.EmployeeDto.name;
                existingEmployee.email_address = request.EmployeeDto.email_address;
                existingEmployee.phone_number = request.EmployeeDto.phone_number;
                existingEmployee.gender=request.EmployeeDto.gender;
                existingEmployee.cafe_id = request.EmployeeDto.cafe_id;
                existingEmployee.start_date = request.EmployeeDto.start_date;
                   
                return employeeRepository.UpdateEmployeeAsync(existingEmployee);
                
            }
            throw new ArgumentException("Employee not found or invalid data provided.");
        }
    }
}
