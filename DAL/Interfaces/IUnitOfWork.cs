﻿using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        ILikeRepository LikeRepository { get; }
        Task<int> SaveAsync();
    }
}
