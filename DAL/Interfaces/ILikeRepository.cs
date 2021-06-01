using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        IEnumerable<Like> GetAllLikesByUserId(int id);
        IEnumerable<Like> GetAllLikesByPhotoId(int id);
        Task<Like> GetByIdWithDetailsAsync(int id);
    }
}
