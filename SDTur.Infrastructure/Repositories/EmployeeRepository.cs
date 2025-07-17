using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            return await _dbSet.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<Employee> GetEmployeeWithBranchAsync(int id)
        {
            return await _dbSet
                .Include(e => e.Branch)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByBranchAsync(int branchId)
        {
            return await _dbSet
                .Include(e => e.Branch)
                .Where(e => e.BranchId == branchId && e.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(string position)
        {
            return await _dbSet.Where(e => e.Position == position && e.IsActive).ToListAsync();
        }
    }
} 