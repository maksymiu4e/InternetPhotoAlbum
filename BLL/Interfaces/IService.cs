using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task UpdateAsync(TModel model);
        Task DeleteByIdAsync(int modelId);
        Task CreateAsync(TModel model);
    }
}
