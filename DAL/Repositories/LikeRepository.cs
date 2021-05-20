using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(IPADbContext context) : base (context)
        { 
        }

        private IPADbContext IPADbContext
        {
            get { return _context as IPADbContext; }
        }

        public IEnumerable<Like> GetAllLikesByPhotoId(int id)
        {
            return IPADbContext.Likes.Where(x => x.PhotoId == id).ToList();
        }

        public IEnumerable<Like> GetAllLikesByUserId(int id)
        {
            return IPADbContext.Likes.Where(x => x.Photo.UserId == id).ToList();
        }
    }
}
