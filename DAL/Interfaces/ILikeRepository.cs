using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        IEnumerable<Like> GetAllLikesByUserId(int id);
        IEnumerable<Like> GetAllLikesByPhotoId(int id);
    }
}
