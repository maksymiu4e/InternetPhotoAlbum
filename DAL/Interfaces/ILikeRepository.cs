using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        /// <summary>
        /// Returns all User's Likes
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Collection of likes</returns>
        IEnumerable<Like> GetAllLikesByUserId(int id);

        /// <summary>
        /// Returns all Photo's Likes
        /// </summary>
        /// <param name="id">Photo id</param>
        /// <returns>Collection of likes</returns>
        IEnumerable<Like> GetAllLikesByPhotoId(int id);

        /// <summary>
        /// Returns Like and his Photo
        /// </summary>
        /// <param name="id">Like id</param>
        /// <returns>Full information about Like</returns>
        Task<Like> GetByIdWithDetailsAsync(int id);
    }
}
