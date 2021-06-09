using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(IPADbContext context) : base(context)
        {
        }

        public IEnumerable<Photo> GetAllPhotosByCreationDate(DateTime date)
        {
            return _context.Photos.Where(x => x.CreationDate.Date == date.Date).ToList();
        }

        public IEnumerable<Photo> GetAllPhotosByUserId(int id)
        {
            return _context.Photos.Where(x => x.UserId == id).ToList();
        }
    }
}
