using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserModel>
    {
        //IEnumerable<UserModel> GetAllUsersByRoleId(int id);
    }
}
