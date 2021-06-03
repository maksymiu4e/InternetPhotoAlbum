using System.ComponentModel.DataAnnotations;

namespace InternetPhotoAlbum.ViewModels.Photo
{
    public class UpdatePhotoRequest
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        //public byte[] Content { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Title { get; set; }
    }
}
