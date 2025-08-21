using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;
using System;

namespace CafeApp.Application.Commands.AddEmployee
{
    public record AddEmployeeCommand : IRequest<EmployeeEntity>
    {
        public AddEmployeeDto Employee { get; set; }

        public AddEmployeeCommand(AddEmployeeDto employee)
        {
            Employee = employee;
        }
    }


 
}
