using System.ComponentModel.DataAnnotations;

namespace InternetPhotoAlbum.ViewModels.User
{
    public class SignInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
