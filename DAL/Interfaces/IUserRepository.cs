using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        //IEnumerable<User> GetAllUsersByRoleId(int id);
    }
}
