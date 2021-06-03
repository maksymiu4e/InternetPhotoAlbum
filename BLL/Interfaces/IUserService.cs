using BLL.Models.User;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserModel>
    {
        Task<SignUpModel> SignUpAsync(SignUpModel signUpModel);
        Task<SignInResult> SignInAsync(SignInModel signInModel);
        Task SignOut();
    }
}
