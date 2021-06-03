using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LikeService : Service<LikeModel, Like>, ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, unitOfWork.LikeRepository, mapper)
        {
            _likeRepository = _unitOfWork.LikeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LikeModel>> GetAllLikesByPhotoIdAsync(int id)
        {
            var photoLikes = _likeRepository.GetAllLikesByPhotoId(id);
            return _mapper.Map<IEnumerable<Like>, IEnumerable<LikeModel>>(photoLikes);
        }

        public async Task<IEnumerable<LikeModel>> GetAllLikesByUserIdAsync(int id)
        {
            var userLikes = _likeRepository.GetAllLikesByUserId(id);
            return  _mapper.Map<IEnumerable<Like>, IEnumerable<LikeModel>>(userLikes);
        }
    }
}
