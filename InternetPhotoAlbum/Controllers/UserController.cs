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
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

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
                cfg.CreateMap<UserModel, UserSignUpModel>()
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
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            SignUpModel res = await _userService.SignUpAsync(signUpModel);

            if (res.Errors.Count > 0)
            {
                return BadRequest(res.Errors);
            }

            return Ok(signUpModel);

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            SignInResult res = await _userService.SignInAsync(signInModel);

            if (!res.Succeeded)
            {
                return Unauthorized();
            }

            return Ok();

        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut()
        {
           await _userService.SignOut();

            return Ok();
        }
    }
}
