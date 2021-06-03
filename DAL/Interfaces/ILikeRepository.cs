using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        // TODO XML Doc
        IEnumerable<Like> GetAllLikesByUserId(int id);
        IEnumerable<Like> GetAllLikesByPhotoId(int id);
        Task<Like> GetByIdWithDetailsAsync(int id);
    }
}
