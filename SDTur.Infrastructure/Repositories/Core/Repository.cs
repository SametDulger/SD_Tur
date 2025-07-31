using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Core;
using SDTur.Core.Interfaces.Core;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories.Core
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly SDTurDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(SDTurDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.UpdatedDate = DateTime.UtcNow;
                _dbSet.Update(entity);
            }
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public virtual IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }
    }
} 