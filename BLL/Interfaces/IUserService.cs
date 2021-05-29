using BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserModel>
    {
        Task<SignUpModel> SignUpAsync(SignUpModel signUpModel);
        Task<SignInResult> SignInAsync(SignInModel signInModel);
        Task SignOut();
        //IEnumerable<UserModel> GetAllUsersByRoleId(int id);
        //Task<UserModel>
    }
}
