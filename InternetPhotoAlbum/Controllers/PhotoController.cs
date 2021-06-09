using AutoMapper;
using BLL.Interfaces;
using InternetPhotoAlbum.ViewModels.Photo;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Security.Claims;
using static BLL.Shared.Enums;

namespace InternetPhotoAlbum.Controllers
{
    //[AllowAnonymous]
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdatePhotoRequest, PhotoModel>().ReverseMap();
            }));
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Admin))]
        //[Authorize]
        //[Authorize(Policy = "RequireAdministratorRole")]
        public async Task<ActionResult<List<PhotoModel>>> GetAll()
        {
            var result = await _photoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<PhotoModel>>> GetByIdAsync(int id)
        {
            var result = await _photoService.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _photoService.GetByIdAsync(id);
            if (res is null)
            {
                return NotFound();
            }

            await _photoService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync(UpdatePhotoRequest updatePhoto)
        {
            var model = _mapper.Map<UpdatePhotoRequest, PhotoModel>(updatePhoto);
            var photoToChange = await _photoService.GetByIdAsync(model.Id);
            if (photoToChange is null)
            {
                return NotFound();
            }

            await _photoService.UpdateAsync(photoToChange);
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<PhotoModel>> GetAllPhotosByCreationDate(DateTime date)
        {
            DateTime dateAppReleased = new DateTime(2021, 01, 01);
            if (date < dateAppReleased)
            {
                return BadRequest("It is new App. Not old as you");
            }

            var result = _photoService.GetAllPhotosByCreationDate(date);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<PhotoModel>> GetAllPhotosByUserId(int id)
        {
            var result = _photoService.GetAllPhotosByUserId(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromForm] PhotoModel model, IFormFile img)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (Stream stream = img.OpenReadStream())
            using (MemoryStream memmoryStream = new MemoryStream())
            {
                img.CopyTo(memmoryStream);
                model.Content = memmoryStream.ToArray();
            }

            model.CreationDate = DateTime.Now;
            model.UserId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            try
            {
                await _photoService.CreateAsync(model);
            }
            catch (Exception)
            {

                return Ok("Uploading failed");
            }


            return Ok("Success uploaded");
        }
    }
}
