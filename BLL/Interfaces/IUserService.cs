using BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserModel>
    {
        Task<UserModel> SignUpAsync(UserModel userModel);
        Task<SignInResult> SignInAsync(UserModel userModel);
        Task SignOut();
    }
}
