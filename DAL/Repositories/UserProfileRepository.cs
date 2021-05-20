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
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(IPADbContext context) : base(context)
        {
        }

        private IPADbContext IPADbContext 
        {
            get { return _context as IPADbContext; } 
        }

        public IEnumerable<UserProfile> GetByUserId(int id)
        {
            return IPADbContext.UserProfiles.Where(x => x.UserId == id).ToList();
        }
    }
}
