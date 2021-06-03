using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IPADbContext _context;
        protected DbSet<TEntity> _entityDbSet;
        protected Repository(IPADbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            _context = context;
            _entityDbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _entityDbSet.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _entityDbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entityDbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _entityDbSet.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _entityDbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
