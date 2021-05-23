using BLL.Models;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILikeService : IService<LikeModel>
    {
        //Task<IEnumerable<Like>> GetAllAsync();
        //Task<Like> GetByIdAsync(int id);
        IEnumerable<LikeModel> GetAllLikesByUserId(int id);
        IEnumerable<LikeModel> GetAllLikesByPhotoId(int id);
    }
}
