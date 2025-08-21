using CafeApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Core.Interfaces
{
    public interface ICafeRepository
    {
        Task<List<CafeEntity>> GetCafesAsync();
        Task<CafeEntity> GetCafeByIdAsync(Guid id);
        Task<CafeEntity> AddCafeAsync(CafeEntity employee);
        Task<CafeEntity> UpdateCafeAsync(CafeEntity cafe);
        Task<bool> DeleteCafeAsync(CafeEntity cafe);
    }
}
