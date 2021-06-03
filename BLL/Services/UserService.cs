using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using static BLL.Shared.Enums;

namespace BLL.Services
{
    public class UserService : Service<UserModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager) : base(unitOfWork, unitOfWork.UserRepository, mapper)
        {
            _userRepository = unitOfWork.UserRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<UserModel> SignUpAsync(UserModel userModel)
        {
            User user = _mapper.Map<UserModel, User>(userModel);
            user.UserName = userModel.Email;

            IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                int errorCount = 1;
                result.Errors.ToList().ForEach(item =>
                {
                    userModel.Errors.Add($"Error {errorCount++} - {item.Description}");
                });
                return userModel;
            }

            await _userManager.AddToRoleAsync(user, UserRole.Registered.ToString());

            return userModel;
        }

        public async Task<SignInResult> SignInAsync(UserModel userModel)
        {
            User user = await _userManager.FindByEmailAsync(userModel.Email);

            if (user is null)
            {
                return SignInResult.Failed;
            }
            return await _signInManager.PasswordSignInAsync(user, userModel.Password, isPersistent: false, lockoutOnFailure: false);
            
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
