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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IPADbContext context) : base(context)
        {
        }

        private IPADbContext IPADbContext 
        {
            get { return _context as IPADbContext; }
        }

        public IEnumerable<User> GetAllUsersByRoleId(int id)
        {
            return IPADbContext.Users.Where(x => x.RoleId == id).ToList();
        }
    }
}
