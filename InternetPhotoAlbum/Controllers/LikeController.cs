using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InternetPhotoAlbum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService ?? throw new ArgumentNullException(nameof(likeService));
        }

        [HttpGet]
        public async Task<ActionResult<List<LikeModel>>> GetAll()
        {
            var result = await _likeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<LikeModel>>> GetByIdAsync(int id)
        {
            var result = await _likeService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<LikeModel>>> GetAllLikesByPhotoId(int id)
        {
            var result = await _likeService.GetAllLikesByPhotoIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<LikeModel>>> GetAllLikesByUserId(int id)
        {
            var result = await _likeService.GetAllLikesByUserIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _likeService.GetByIdAsync(id);
            if (res is null)
            {
                return NotFound();
            }

            await _likeService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAsync(LikeModel model)
        {
            await _likeService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAsync(LikeModel model)
        {
            var appUser = HttpContext.User;
            if (!appUser.Identity.IsAuthenticated)
            {
                return Forbid("Please, SignIn into your account.");
            }

            model.UserId = int.Parse(appUser.FindFirstValue(ClaimTypes.NameIdentifier));

            IEnumerable<LikeModel> userLikes = await _likeService.GetAllLikesByUserIdAsync(model.UserId);

            List<LikeModel> likesPerPhoto = userLikes.Where(x => x.PhotoId == model.PhotoId).Select(x => x).ToList();

            if (likesPerPhoto.Count > 0)
            {
                await _likeService.DeleteByIdAsync(likesPerPhoto.FirstOrDefault().Id);
                return Ok();
            }

            await _likeService.CreateAsync(model);
            return Ok(model);
        }
    }
}