using CafeApp.Core.Entities;
using CafeApp.Core.Interfaces;
using CafeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Infrastructure.Repositories
{
    public class CafeRepository(AppDbContext dbContext) : ICafeRepository
    {
        public async Task<List<CafeEntity>> GetCafesAsync()
        {
            return await dbContext.Cafes.Include(c=> c.Employees)
                .AsNoTracking()
                .ToListAsync();
        }
      
        public async Task<CafeEntity> AddCafeAsync(CafeEntity cafe)
        {
            await dbContext.Cafes.AddAsync(cafe);
            await dbContext.SaveChangesAsync();
            return cafe;
        }
       
        public async Task<CafeEntity> UpdateCafeAsync(CafeEntity cafe)
        {
            await dbContext.SaveChangesAsync();
            return cafe;
        }
        public async Task<CafeEntity> GetCafeByIdAsync(Guid id)
        {
            return await dbContext.Cafes.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<bool> DeleteCafeAsync(CafeEntity cafe)
        {   //Get all employees associated with the cafe and remove them first
            var employees =  dbContext.Employees.Where(e => e.cafe_id == cafe.id).ToList();
                dbContext.Employees.RemoveRange(employees);
            await dbContext.SaveChangesAsync();
            // Now delete the cafe
                dbContext.Cafes.Remove(cafe);
            return await dbContext.SaveChangesAsync() > 0;           
        }
    }
    }
