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
    }
}
