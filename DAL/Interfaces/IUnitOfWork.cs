using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        ILikeRepository LikeRepository { get; }
        Task<int> SaveAsync();
    }
}
