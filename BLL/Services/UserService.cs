using AutoMapper;
using BLL.Interfaces;
using BLL.Models.User;
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


        public async Task<SignUpModel> SignUpAsync(SignUpModel signUpModel)
        {
            User user = _mapper.Map<SignUpModel, User>(signUpModel);
            user.UserName = signUpModel.Email;

            IdentityResult result = await _userManager.CreateAsync(user, signUpModel.Password);
            if (!result.Succeeded)
            {
                int errorCount = 1;
                result.Errors.ToList().ForEach(item =>
                {
                    signUpModel.Errors.Add($"Error {errorCount++} - {item.Description}");
                });
                return signUpModel;
            }

            await _userManager.AddToRoleAsync(user, UserRole.Registered.ToString());

            return signUpModel;
        }

        public async Task<SignInResult> SignInAsync(SignInModel signInModel)
        {
            User user = await _userManager.FindByEmailAsync(signInModel.Email);

            if (user is null)
            {
                return SignInResult.Failed;
            }
            return await _signInManager.PasswordSignInAsync(user, signInModel.Password, isPersistent: false, lockoutOnFailure: false);
            
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
