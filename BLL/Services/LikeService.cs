using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
        }
        public async Task<IEnumerable<Like>> GetAllAsync()
        {
            return await _likeRepository.GetAllAsync();
        }

        public IEnumerable<LikeModel> GetAllLikesByPhotoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LikeModel> GetAllLikesByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Like> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
