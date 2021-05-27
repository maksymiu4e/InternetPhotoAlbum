using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IPADbContext context) : base(context)
        {
        }

        //public IEnumerable<User> GetAllUsersByRoleId(int id)
        //{
        //    return _context.Users.Where(x => x.).UserRoles.Where(x => x.RoleId == id).ToList();
        //}

        //private IPADbContext IPADbContext 
        //{
        //    get { return _context as IPADbContext; }
        //}

        //public IEnumerable<User> GetAllUsersByRoleId(int id)
        //{
        //    return IPADbContext.Users.Where(x => x.RoleId == id).ToList();
        //}
    }
}
