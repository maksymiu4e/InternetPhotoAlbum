using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using InternetPhotoAlbum.PLModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetPhotoAlbum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly UserManager<UserModel> _userManager;
        private readonly IMapper _mapper;
        //private readonly UserMembershipProvider _userMembershipProvider;


        public UserController(IUserService userService/*, UserManager<UserModel> userManager*/) 
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, UserSignUpModel> ()
                        .ForMember(u => u.Email, opt => opt.MapFrom(ur => ur.Email)).ReverseMap();
            }));
            //_userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _userService.GetByIdAsync(id);
            if (res is null)
            {
                return NotFound();
            }

            await _userService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync(UserModel model)
        {
            await _userService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserSignUpModel userSignUpModel)
        {
            //var user = _mapper.Map<UserSignUpModel, UserModel>(userSignUpModel);

            //var userCreateResult = await _userManager.CreateAsync(user, userSignUpModel.Password);

            await _userService.CreateAsync(new UserModel
            {
                Email = userSignUpModel.Email,
                FirstName = userSignUpModel.FirstName,
                LastName = userSignUpModel.LastName,
                Password = userSignUpModel.Password
            });

            return Ok();
            //if (userCreateResult.Succeeded)
            //{
            //    return Created(string.Empty, string.Empty);
            //}

            //return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        //[HttpPost("SignIn")]
        //public async Task<IActionResult> SignIn(UserSignInModel userSignInModel)
        //{
        //    //var user = _userManager.Users.SingleOrDefault(u => u.Email == userSignInModel.Email);
        //    var user = null;
        //    if (user is null)
        //    {
        //        return NotFound("User not found");
        //    }

        //    //var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);

        //    //if (userSigninResult)
        //    //{
        //    //    return Ok();
        //    //}

        //    return BadRequest("Email or password incorrect.");
        //}

        [HttpPost("SigningUp")]
        public async Task<IActionResult> SignUp(UserModel user)
        {
            //var user = _mapper.Map<UserSignUpModel, UserModel>(userSignUpModel);

            //var userCreateResult = await _userManager.CreateAsync(user, userSignUpModel.Password);
            await _userService.CreateAsync(user);
            //await _userService.CreateAsync(new UserModel
            //{
            //    Email = userSignUpModel.Email,
            //    FirstName = userSignUpModel.FirstName,
            //    LastName = userSignUpModel.LastName,
            //    Password = userSignUpModel.Password
            //});

            return Ok();
        }

    }
}
