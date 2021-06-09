using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using InternetPhotoAlbum.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BLL.Shared.Enums;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace InternetPhotoAlbum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignUpViewModel, UserModel>().ReverseMap();
                cfg.CreateMap<SignInViewModel, UserModel>().ReverseMap();
            }));
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<List<UserModel>>> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
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
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> UpdateAsync(UserModel model)
        {
            await _userService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            UserModel model = _mapper.Map<SignUpViewModel, UserModel>(signUpViewModel);
            var res = await _userService.SignUpAsync(model);

            if (res.Errors.Count > 0)
            {
                return BadRequest(res.Errors);
            }

            return Ok(signUpViewModel);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            UserModel model = _mapper.Map<SignInViewModel, UserModel>(signInViewModel);
            SignInResult res = await _userService.SignInAsync(model);

            if (!res.Succeeded)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            var appUser = HttpContext.User;
            if (!appUser.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            await _userService.SignOut();

            return Ok();
        }
    }
}
