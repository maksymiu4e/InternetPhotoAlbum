using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IPADbContext context) : base(context)
        {
        }

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
