using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILikeService : IService<LikeModel>
    {
        //Task<IEnumerable<Like>> GetAllAsync();
        //Task<Like> GetByIdAsync(int id);
        Task<IEnumerable<LikeModel>> GetAllLikesByUserIdAsync(int id);
        Task<IEnumerable<LikeModel>> GetAllLikesByPhotoIdAsync(int id);
    }
}
