using CafeApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee);
        Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync();
        Task<EmployeeEntity> GetEmployeeByIdAsync(string employeeid);
        Task <bool> DeleteEmployeeAsync(EmployeeEntity employee);
        Task<EmployeeEntity> UpdateEmployeeAsync(EmployeeEntity employee);

        
    }
}
