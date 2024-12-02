using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TrixTutorDBContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(TrixTutorDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

    }

}
