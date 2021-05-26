using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(IPADbContext context) : base(context)
        {
        }
        //private IPADbContext IPADbContext
        //{
        //    get { return _context as IPADbContext; }
        //}

        public IEnumerable<Photo> GetAllPhotosByCreationDate(DateTime date)
        {
            return _context.Photos.Where(x => x.CreationDate == date).ToList();
        }

        //public IEnumerable<Photo> GetAllPhotosByRoleId(int id)
        //{
        //    return IPADbContext.Photos.Where(x => x.User.RoleId == id).ToList();
        //}

        public IEnumerable<Photo> GetAllPhotosByUserId(int id)
        {
            return _context.Photos.Where(x => x.UserId == id).ToList();
        }
    }
}
