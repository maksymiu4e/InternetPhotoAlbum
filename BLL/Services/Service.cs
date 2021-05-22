using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    public abstract class Service<TModel> : IService<TModel> where TModel : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
