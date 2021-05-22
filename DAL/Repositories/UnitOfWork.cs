using DAL.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //private IUserProfileRepository _userProfileRepository;
        private IUserRepository _userRepository;
        //private IRoleRepository _roleRepository;
        private IPhotoRepository _photoRepository;
        private ILikeRepository _likeRepository;
        private readonly IPADbContext _dbContext;

        public UnitOfWork(IPADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_dbContext);

        //public IUserProfileRepository UserProfileRepository => _userProfileRepository = _userProfileRepository ?? new UserProfileRepository(_dbContext);

        //public IRoleRepository RoleRepository => _roleRepository = _roleRepository ?? new RoleRepository(_dbContext);

        public IPhotoRepository PhotoRepository => _photoRepository = _photoRepository ?? new PhotoRepository(_dbContext);

        public ILikeRepository LikeRepository => _likeRepository = _likeRepository ?? new LikeRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
