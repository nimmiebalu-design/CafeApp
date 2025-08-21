using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand
         : IRequest<bool>
    {
        public string EmployeeId { get; set; }
        public DeleteEmployeeCommand(string employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
