using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILikeService : IService<LikeModel>
    {
        /// <summary>
        /// Returns all User's Likes
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Collection of likes</returns>
        Task<IEnumerable<LikeModel>> GetAllLikesByUserIdAsync(int id);

        /// <summary>
        /// Returns all Photo's Likes
        /// </summary>
        /// <param name="id">Photo id</param>
        /// <returns>Collection of likes</returns>
        Task<IEnumerable<LikeModel>> GetAllLikesByPhotoIdAsync(int id);
    }
}
