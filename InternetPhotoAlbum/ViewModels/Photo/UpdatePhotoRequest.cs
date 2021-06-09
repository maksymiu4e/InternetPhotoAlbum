using System.ComponentModel.DataAnnotations;

namespace InternetPhotoAlbum.ViewModels.Photo
{
    public class UpdatePhotoRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Title { get; set; }
    }
}
