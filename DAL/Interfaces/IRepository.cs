using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        //void Delete(TEntity entity);
        Task DeleteByIdAsync(int id);
    }
}
