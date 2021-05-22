using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly IPADbContext _context;
        protected DbSet<TEntity> _entityDbSet;
        public Repository(IPADbContext context)
        {
            _context = context;
            _entityDbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        //public void Delete(TEntity entity)
        //{
        //    _context.Set<TEntity>().Remove(entity);
        //}

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<TEntity>().Remove(entity);
        }

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        //{
        //    return _context.Set<TEntity>().Where(expression);
        //}

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entityDbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entityDbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().FirstOrDefault(x => x == entity);
        }
    }
}
