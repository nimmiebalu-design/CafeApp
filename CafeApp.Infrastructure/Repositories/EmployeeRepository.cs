using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using CafeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync()
        {
            return await dbContext.Employees
                .Include(e => e.cafe)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<EmployeeEntity> GetEmployeeByIdAsync(string id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity)

        {            
            await dbContext.Employees.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity; // Assuming 1 indicates success
        }     
        public async Task<EmployeeEntity> UpdateEmployeeAsync(EmployeeEntity entity)
        {   
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteEmployeeAsync(EmployeeEntity employee)
        {
            dbContext.Employees.Remove(employee);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
