using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    public abstract class Service<TModel, TEntity> : IService<TModel> 
        where TModel : class
        where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TModel>().ReverseMap();
            }));

        }
        public async Task DeleteByIdAsync(int modelId)
        {
            await _repository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(await _repository.GetAllAsync());
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            return _mapper.Map<TEntity, TModel>(await _repository.GetByIdAsync(id));
        }

        public void Update(TModel model)
        {
             _repository.Update(_mapper.Map<TModel, TEntity>(model));
        }
    }
}
