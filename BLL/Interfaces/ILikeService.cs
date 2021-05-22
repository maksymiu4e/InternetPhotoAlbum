using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ILikeService : IService<LikeModel>
    {
        IEnumerable<LikeModel> GetAllLikesByUserId(int id);
        IEnumerable<LikeModel> GetAllLikesByPhotoId(int id);
    }
}
