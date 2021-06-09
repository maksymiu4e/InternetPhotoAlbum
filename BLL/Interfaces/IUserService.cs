using BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserModel>
    {
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userModel">user model with needed params</param>
        /// <returns>New UserModel</returns>
        Task<UserModel> SignUpAsync(UserModel userModel);

        /// <summary>
        /// SignIn user into the system
        /// </summary>
        /// <param name="userModel">userModel to logIn</param>
        /// <returns>Result about signIn</returns>
        Task<SignInResult> SignInAsync(UserModel userModel);

        /// <summary>
        /// SignOut from system
        /// </summary>
        /// <returns></returns>
        Task SignOut();
    }
}
