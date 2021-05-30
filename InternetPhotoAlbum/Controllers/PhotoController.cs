using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InternetPhotoAlbum.Controllers
{
    //[AllowAnonymous]
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
        }

        [HttpGet]
        //[Authorize(Roles = nameof(UserRole.Admin))]
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
            var foo = HttpContext.User;
            var result = await _photoService.GetByIdAsync(id);
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
        //[Route("[action]")]
        public async Task<IActionResult> UpdateAsync(UpdatePhotoRequest model)
        {
            var photoToChange = await _photoService.GetByIdAsync(model.Id);
            if (photoToChange is null)
            {
                return NotFound();
            }

            //photoToChange.Title = model.Title;
            await _photoService.UpdateAsync(photoToChange);
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<PhotoModel>> GetAllPhotosByCreationDate(DateTime date)
        {
            var result = _photoService.GetAllPhotosByCreationDate(date);
            return Ok(result);
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<PhotoModel>> GetAllPhotosByUserId(int id)
        {
            var result = _photoService.GetAllPhotosByUserId(id);
            return Ok(result);
        }

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> CreateAsync(PhotoModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    await _photoService.CreateAsync(model);
        //    return Ok(model);
        //}

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
