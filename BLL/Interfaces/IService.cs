using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Base Service with basic methods
    /// </summary>
    public interface IService<TModel> where TModel : class
    {
        /// <summary>
        /// Returns all models
        /// </summary>
        /// <returns>Collection of models</returns>
        Task<IEnumerable<TModel>> GetAllAsync();

        /// <summary>
        /// Returns all models by id
        /// </summary>
        /// <param name="id">model id</param>
        /// <returns>Model</returns>
        Task<TModel> GetByIdAsync(int id);

        /// <summary>
        /// Updates model
        /// </summary>
        /// <param name="model">model to update</param>
        /// <returns></returns>
        Task UpdateAsync(TModel model);

        /// <summary>
        /// Delete model by id
        /// </summary>
        /// <param name="modelId">model id</param>
        /// <returns></returns>
        Task DeleteByIdAsync(int modelId);

        /// <summary>
        /// Create new model
        /// </summary>
        /// <param name="model">model to create</param>
        /// <returns>New model</returns>
        Task CreateAsync(TModel model);
    }
}
