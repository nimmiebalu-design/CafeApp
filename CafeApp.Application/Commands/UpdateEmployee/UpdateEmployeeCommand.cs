using CafeApp.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand:IRequest<EmployeeEntity>
    {
        public UpdateEmployeeDto EmployeeDto { get; }
        public UpdateEmployeeCommand(UpdateEmployeeDto employeedto)
        {
            EmployeeDto = employeedto;
        }
    }
}
