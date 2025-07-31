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
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Branch>> GetActiveBranchesAsync()
        {
            return await _dbSet.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<Branch> GetBranchWithEmployeesAsync(int id)
        {
            return await _dbSet
                .Include(b => b.Employees)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
} 