using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BLL.Services
{
    public abstract class Service<TModel, TEntity> : IService<TModel>
        where TModel : class
        where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            //_mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<TEntity, TModel>().ReverseMap();
            //}));

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
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                return null;
            }
            return _mapper.Map<TModel>(entity);
        }

        public async Task UpdateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _repository.UpdateAsync(entity);
        }

        public async Task CreateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);

            await _repository.CreateAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
