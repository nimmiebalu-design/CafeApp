using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<GetEmployeesDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<GetEmployeesDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {

            var employees = await _employeeRepository.GetEmployeesAsync();

            if (request.CafeId.HasValue && request.CafeId.Value != Guid.Empty)
            {
                
                //Filter out employees with empty or null café IDs
                employees = employees
                   .Where (e=>e.cafe_id != Guid.Empty && e.cafe_id!= null)
                    .ToList();
                // Filter by café ID if provided
                    employees = employees
                    .Where(e => e.cafe_id == request.CafeId)
                    .ToList();
            }
            var now = DateTime.UtcNow;
            // Map to DTOs and calculate days worked
            return employees.Select(e => new GetEmployeesDto
            {
                id = e.id,
                name = e.name,
                email_address = e.email_address,
                phone_number = e.phone_number,
                gender = e.gender,
                days_worked = e.start_date.HasValue ? (now - e.start_date.Value).Days : 0,
                cafe_id = e.cafe_id.HasValue ? e.cafe_id : Guid.Empty,
                cafe_name = e.cafe?.name ?? "",
                start_date = e.start_date.HasValue ? e.start_date : null
            })
              .OrderByDescending(e => e.days_worked)
              .ToList();
        }
    }
}
