using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Master;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Master
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            return await _dbSet.Where(e => e.IsActive && !e.IsDeleted).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeWithBranchAsync(int id)
        {
            return await _dbSet
                .Include(e => e.Branch)
                .FirstOrDefaultAsync(e => e.Id == id && e.IsActive && !e.IsDeleted);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByBranchAsync(int branchId)
        {
            return await _dbSet
                .Include(e => e.Branch)
                .Where(e => e.BranchId == branchId && e.IsActive && !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(string position)
        {
            return await _dbSet.Where(e => e.Position == position && e.IsActive && !e.IsDeleted).ToListAsync();
        }
    }
} 