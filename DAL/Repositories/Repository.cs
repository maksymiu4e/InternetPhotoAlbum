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
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityDbSet = context.Set<TEntity>();
        }

        ///<inheritdoc/>
        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _entityDbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entityDbSet.ToListAsync();
        }

        ///<inheritdoc/>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _entityDbSet.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _entityDbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
