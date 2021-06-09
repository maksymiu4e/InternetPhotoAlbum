using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(IPADbContext context) : base(context)
        {
        }

        ///<inheritdoc/>
        public IEnumerable<Like> GetAllLikesByPhotoId(int id)
        {
            return _context.Likes.Where(x => x.PhotoId == id).ToList();
        }

        ///<inheritdoc/>
        public IEnumerable<Like> GetAllLikesByUserId(int id)
        {
            return _context.Likes.Where(x => x.UserId == id).ToList();
        }

        ///<inheritdoc/>
        public async Task<Like> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Likes.Where(x => x.Id == id).Include(p => p.Photo).FirstOrDefaultAsync();
        }
    }
}
