using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LikeService : Service<LikeModel, Like>, ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        //public LikeService(ILikeRepository likeRepository)
        //{
        //    _likeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
        //}
        public LikeService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.LikeRepository)
        {
            _likeRepository = _unitOfWork.LikeRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Like, LikeModel>().ReverseMap();
            }));
        }

        //public async Task<IEnumerable<LikeModel>> GetAllAsync()
        //{
        //    return await _likeRepository.GetAllAsync();
        //}

        public IEnumerable<LikeModel> GetAllLikesByPhotoId(int id)
        {
            var photoLikes = _likeRepository.GetAllLikesByPhotoId(id);
            return _mapper.Map<IEnumerable<Like>, IEnumerable<LikeModel>>(photoLikes);
        }

        public IEnumerable<LikeModel> GetAllLikesByUserId(int id)
        {
            var userLikes = _likeRepository.GetAllLikesByUserId(id);
            return _mapper.Map<IEnumerable<Like>, IEnumerable<LikeModel>>(userLikes);
        }
    }
}
