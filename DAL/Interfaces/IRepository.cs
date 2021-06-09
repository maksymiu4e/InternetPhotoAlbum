using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    /// <summary>
    /// Base Repository with basic CRUD methods
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Returns all entity by id
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>Entity</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">entity to update</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns></returns>
        Task DeleteByIdAsync(int id);

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity">entity to create</param>
        /// <returns>New entity</returns>
        Task<TEntity> CreateAsync(TEntity entity);
    }
}
