using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IPhotoService _photoService;
        private readonly IUserService _userService;

        public LikeController(ILikeService likeService, IPhotoService photoService, IUserService userService)
        {
            _likeService = likeService ?? throw new ArgumentNullException(nameof(likeService));
            _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
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
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<LikeModel>>> GetAllLikesByPhotoId(int id)
        {
            PhotoModel result = await _photoService.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            IEnumerable<LikeModel> likes = await _likeService.GetAllLikesByPhotoIdAsync(id);
            return Ok(likes);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<LikeModel>>> GetAllLikesByUserId(int id)
        {
            UserModel result = await _userService.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            IEnumerable<LikeModel> likes = await _likeService.GetAllLikesByUserIdAsync(id);
            return Ok(likes);
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

        [Authorize]
        [HttpPost]
        [Route("[action]/{photoId}")]
        public async Task<IActionResult> CreateAsync(int photoId)
        {
            var res = await _photoService.GetByIdAsync(photoId);
            if (res is null)
            {
                return NotFound();
            }

            var appUser = HttpContext.User;
            if (!appUser.Identity.IsAuthenticated)
            {
                return Forbid("Please, SignIn into your account.");
            }

            LikeModel model = new LikeModel
            {
                UserId = int.Parse(appUser.FindFirstValue(ClaimTypes.NameIdentifier)),
                PhotoId = photoId
            };

            IEnumerable<LikeModel> userLikes = await _likeService.GetAllLikesByUserIdAsync(model.UserId);

            List<LikeModel> likesPerPhoto = userLikes.Where(x => x.PhotoId == model.PhotoId).Select(x => x).ToList();

            if (likesPerPhoto.Count > 0)
            {
                await _likeService.DeleteByIdAsync(likesPerPhoto.FirstOrDefault().Id);
                return Ok("Like deleted");
            }

            await _likeService.CreateAsync(model);
            return Ok("Like added");
        }
    }
}