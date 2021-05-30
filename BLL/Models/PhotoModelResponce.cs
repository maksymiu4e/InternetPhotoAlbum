using Microsoft.AspNetCore.Http;
using System.IO;

namespace BLL.Models
{
    public class PhotoModelResponce
    {
        //public int UserId { get; set; }
        public IFormFile Content { get; set; }
        //public string Title { get; set; }

        //public byte[] Memory()
        //{
        //    byte[] bytes = null;
        //    using (var img = Content.OpenReadStream())
        //    using (MemoryStream memmoryStream = new MemoryStream())
        //    {
        //        img.CopyTo(memmoryStream);
        //        bytes = memmoryStream.ToArray();
        //    }
        //    return bytes;
        //}

    }
}
