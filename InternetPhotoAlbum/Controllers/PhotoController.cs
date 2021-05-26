using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetPhotoAlbum.Controllers
{
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
        public async Task<ActionResult<List<PhotoModel>>> GetAll()
        {
            var result = await _photoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<PhotoModel>>> GetByIdAsync(int id)
        {
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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync(PhotoModel model)
        {
            await _photoService.UpdateAsync(model);
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
    }
}
