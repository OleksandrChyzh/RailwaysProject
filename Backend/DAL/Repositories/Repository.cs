using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
        public class Repository<T> : IRepository<T> where T : class
        {
            protected readonly RailwayContext _context;
            protected readonly DbSet<T> _dbSet;

            public Repository(RailwayContext context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<T?> GetByIdAsync(object id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task AddAsync(T entity)
            {
                await _dbSet.AddAsync(entity);
                await SaveAsync();
            }

            public async Task UpdateAsync(T entity)
            {
                _dbSet.Update(entity);
                await SaveAsync();
            }

            public async Task DeleteAsync(object id)
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await SaveAsync();
                }
            }

            public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }

            public async Task SaveAsync()
            {
                await _context.SaveChangesAsync();
            }
        }

}
