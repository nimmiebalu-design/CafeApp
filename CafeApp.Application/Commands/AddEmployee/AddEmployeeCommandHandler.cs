using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        private static readonly Random _random = new();

        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employeeentity = new EmployeeEntity
            {
                id = GenerateEmployeeId(),
                name = request.Employee.Name,
                email_address = request.Employee.EmailAddress,
                phone_number = request.Employee.PhoneNumber,
                gender=request.Employee.Gender,
                cafe_id = request.Employee.CafeId,
                start_date = request.Employee.StartDate
            };
            return await employeeRepository.AddEmployeeAsync(employeeentity);
        }

        private string GenerateEmployeeId()
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomPart = new string(Enumerable.Repeat(chars, 7)
                .Select(s => s[_random.Next(s.Length)]).ToArray());

            return "UI" + randomPart; // e.g. UI7AB12X
        }
    }
}
