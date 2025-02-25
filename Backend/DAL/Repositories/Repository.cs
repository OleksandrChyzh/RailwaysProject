﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
        public DbContext _context { get; }
        public DbSet<TEntity> _dbSet { get; }

        public Repository(DbContext context)
        {
            _context = (RailwayContext)context; // Явне приведення
            _dbSet = context.Set<TEntity>();
        }
        public Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public Task DeleteByIdAsync(int id)
        {
            TEntity entity = _dbSet.Find(id);
            Delete(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id).AsTask();
        }

        public void Update(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }

}
