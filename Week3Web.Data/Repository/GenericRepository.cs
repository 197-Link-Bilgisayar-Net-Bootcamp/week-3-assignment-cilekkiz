using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Web.Data.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }
        public async Task<T> GetByIdAsync(Guid entityId)
        {
            var keyValues = new object[] { entityId };
             return await _dbSet.FindAsync(keyValues);
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
